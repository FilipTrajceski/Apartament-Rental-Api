using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using S_T.Apartaments.Application.Common.DTOs.UserDto;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Entities.Entities;
using S_T.Apartaments.Infrastructure.TokenService;
using S_T.Apartaments.Shared.CustomExceptions.UserExceptions;
using S_T.Apartaments.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace S_T.Apartaments.Infrastructure.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(IMapper mapper, IConfiguration configuration, UserManager<User> userManager, ITokenService tokenService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<CustomResponse> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user is null) return new CustomResponse("User not found!");
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded) return new CustomResponse(result.Errors.ToString());
                return new CustomResponse("User deleted!");
            }
            catch(UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
            catch(UserNotFoundException ex)
            {
                throw new UserNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse> GetAllUsersAsync()
        {
            try
            {
                var response = new CustomResponse<List<UserDto>>();
                var users = await _userManager.Users.ToListAsync();
                var userDtos = users.Select(user => _mapper.Map<UserDto>(user)).ToList();
                response.Result = userDtos;
                response.IsSuccessfull = true;
                return response;

            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
        }

        public async Task<CustomResponse<UserDto>> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userName);
                if (user is null) return new CustomResponse<UserDto>("User not found!");

                UserDto userDto = _mapper.Map<UserDto>(user);
                return new CustomResponse<UserDto>(userDto);

            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }

        }


        public async Task<CustomResponse<LogInTokenDto>> LogInUserAsync(LogInUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request?.UserName))
                {
                    return new CustomResponse<LogInTokenDto>("UserName is a required field!");
                }

                if (string.IsNullOrWhiteSpace(request?.Password))
                {
                    return new CustomResponse<LogInTokenDto>("Password is a required field!");
                }

                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user is null)
                {
                    return new CustomResponse<LogInTokenDto>("User doesn't exist!");
                }

                bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isPasswordValid)
                {
                    return new CustomResponse<LogInTokenDto>("Invalid password!");
                }

                var token = await _tokenService.GenerateTokenAsync(user);
                return new CustomResponse<LogInTokenDto>(new LogInTokenDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ValidTo = token.ValidTo
                });
            }
            catch (UserDataException ex)
            {
                return new CustomResponse<LogInTokenDto>(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return new CustomResponse<LogInTokenDto>(ex.Message);
            }
        }

        public async Task<CustomResponse<RegisterUserDto>> RegisterUserAsync(RegisterUserDto registerUser)
        {
            try
            {
                if (string.IsNullOrEmpty(registerUser.UserName)) throw new UserDataException("UserName can't be empty!");
                if (string.IsNullOrEmpty(registerUser.Password)) throw new UserDataException("Password can't be empty!");
                if (string.IsNullOrEmpty(registerUser.Email)) throw new UserDataException("Email can't be empty!");

                if(registerUser.Password != registerUser.ConfirmPassword) { return new("Passwords do not match!"); }

                var user = new UserDto()
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    HasCheckedInPreviously = false,
                    Country = registerUser.Country,
                    Role = registerUser.UserRole,

                };
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return new(result.Errors.Select(x => x.Description));
                };

                return new("Registered Successfully");
            }
            catch(UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
        }
    }
}
