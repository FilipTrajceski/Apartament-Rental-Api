using S_T.Apartaments.Application.Common.DTOs.UserDto;
using S_T.Apartaments.Entities.Entities;
using S_T.Apartaments.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<CustomResponse<RegisterUserDto>> RegisterUserAsync(RegisterUserDto registerUser);

        Task<CustomResponse<LogInTokenDto>> LogInUserAsync(LogInUserDto request);

        Task<CustomResponse<UserDto>> GetUserByUserNameAsync(string userName);
        Task<CustomResponse> GetAllUsersAsync();

        Task<CustomResponse> DeleteUserAsync(string id);
    }
}
