using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.UserDto
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string ConfirmPassword { get; set; }
        public UserRole UserRole { get; set; }
        public string Email {  get; set; }
        public string Country {  get; set; }
    }
}
