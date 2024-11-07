using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S_T.Apartaments.Application.Common.DTOs.UserDto;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Shared.CustomExceptions.UserExceptions;
using S_T.Apartaments.Shared.Responses;

namespace S_T.Apartaments.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                var request = new RegisterUserDto
                {
                    Email = registerUserDto.Email,
                    Password = registerUserDto.Password,
                    ConfirmPassword = registerUserDto.ConfirmPassword,
                    UserName = registerUserDto.UserName,
                    Country = registerUserDto.Country,
                    UserRole = registerUserDto.UserRole
                };
                var response = await _userService.RegisterUserAsync(request);
                return Response(response);
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogInUserAsync([FromBody] LogInUserDto model)
        {
            try
            {
                var response = await _userService.LogInUserAsync(model);
                if (response.IsSuccessfull)
                {
                    return Ok(response);
                }
                return BadRequest(response.Errors.ToString());
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userService.GetAllUsersAsync();
                if (response.IsSuccessfull)
                {
                    return Ok(response);
                }
                return BadRequest(response.Errors.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserById(string userName)
        {
            try
            {
                var response = await _userService.GetUserByUserNameAsync(userName);
                if (response.IsSuccessfull)
                {
                    return Ok(response);
                }
                return BadRequest(response.Errors.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var response = await _userService.DeleteUserAsync(id);
                if (response.IsSuccessfull)
                {
                    return Ok(response);
                }
                return BadRequest(response.Errors.ToString());
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

