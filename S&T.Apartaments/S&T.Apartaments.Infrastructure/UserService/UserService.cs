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

        public async Task<CustomResponse> ChangeRoleAsync(ChangeUserRoleDto dto, string adminUserId)
        {
            try
            {
                var admin = await _userManager.FindByIdAsync(adminUserId);
                if(admin.Role != Entities.Enums.UserRole.Admin)
                {
                    return new CustomResponse("You can't perform this action!");
                }

                var user = await _userManager.FindByNameAsync(dto.Username);
                if(user.Role == Entities.Enums.UserRole.Admin){ return new CustomResponse("You can't change admin roles!");}

                if (string.IsNullOrEmpty(dto.Username)) { return new CustomResponse("Username field cannot be empty!"); }
                if(dto.CurrentRole != user.Role) { return new CustomResponse($"User's {user.UserName} Role is not matching with the one you inputed"); }

                if(dto.ChangeRoleTo != Entities.Enums.UserRole.Admin &&
                   dto.ChangeRoleTo != Entities.Enums.UserRole.Owner &&
                   dto.ChangeRoleTo != Entities.Enums.UserRole.Renter)
                {
                    return new CustomResponse($"Invalid role input! {dto.ChangeRoleTo} is not a role");
                }
                user.Role = dto.ChangeRoleTo;

                await _userManager.UpdateAsync(user);

                return new CustomResponse($"User's {user.UserName} role changed!");

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

        public async Task<CustomResponse> DeleteUserAsync(string userName, string userId)
        {
            try
            {
                var owner = await _userManager.FindByIdAsync(userId);
                if (owner.Role == Entities.Enums.UserRole.Admin)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    if (user is null) return new CustomResponse<UserDto>("User not found!");
                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded) return new CustomResponse<UserDto>("Something went wrong!");
                    return new CustomResponse<UserDto>("User deleted!");
                }
                else
                {
                    return new CustomResponse<UserDto>(errors:"You cannot perform this action (Only admins)!");
                }
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

        public async Task<CustomResponse> GetAllUsersAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user.Role == Entities.Enums.UserRole.Admin)
                {
                    var response = new CustomResponse<List<UserDto>>();
                    var users = await _userManager.Users.ToListAsync();
                    var userDtos = users.Select(user => _mapper.Map<UserDto>(user)).ToList();
                    response.Result = userDtos;
                    response.IsSuccessfull = true;
                    return response;
                }
                else
                {
                    return new CustomResponse("You cannot perform this action (only admins)!") { IsSuccessfull= false};
                }

            }
            catch (UserDataException ex)
            {
                throw new UserDataException(ex.Message);
            }
        }

        public async Task<CustomResponse<UserDto>> GetUserByUserNameAsync(string userName, string userId)
        {
            try
            {
                var admin = await _userManager.FindByIdAsync(userId);
                if (admin.Role == Entities.Enums.UserRole.Admin)
                {

                    var user = await _userManager.FindByNameAsync(userName);
                    if (user is null) return new CustomResponse<UserDto>("User not found!") { IsSuccessfull = false };

                    UserDto userDto = _mapper.Map<UserDto>(user);
                    var response = new CustomResponse<UserDto>();
                    response.Result = userDto;
                    response.IsSuccessfull = true;
                    return new CustomResponse<UserDto>(response.Result);
                }
                else
                {
                    return new CustomResponse<UserDto>("You cannot perform this action (only admins)!") { IsSuccessfull= false};
                }

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

                var user = new User()
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    HasCheckedInPreviously = false,
                    Country = registerUser.Country,
                    Role = Entities.Enums.UserRole.Renter,

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
