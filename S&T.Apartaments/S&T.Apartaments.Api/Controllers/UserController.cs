using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S_T.Apartaments.Application.Common.DTOs.UserDto;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Entities.Enums;
using S_T.Apartaments.Shared.CustomExceptions.UserExceptions;
using System.Security.Claims;

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
                return BadRequest(string.Join(", ", response.Errors));
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
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _userService.GetAllUsersAsync(userId);
                if (response.IsSuccessfull)
                {
                    return Ok(response);
                }
                return BadRequest(string.Join(", ", response.Errors));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _userService.GetUserByUserNameAsync(userName, userId);
                if (response.IsSuccessfull)
                {
                    return Ok(response.Result);
                }
                return BadRequest(string.Join(", ", response.Errors));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _userService.DeleteUserAsync(userName, userId);
                if (response.IsSuccessfull)
                {

                    return Ok(response.ToString());
                }
                return BadRequest(string.Join(", ", response.Errors));
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change-roles")]
        public async Task<IActionResult> ChangeRole([FromBody]ChangeUserRoleDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _userService.ChangeRoleAsync(dto, userId);
                if (response.IsSuccessfull) { return Ok(response); }
                return BadRequest(string.Join(", ", response.Errors));
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

