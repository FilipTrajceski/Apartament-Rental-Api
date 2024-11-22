using S_T.Apartaments.Entities.Entities;
using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.UserDto
{
    public class UserDto 
    {
        public string UserName { get; set; }
        public string Email {  get; set; }
        public bool HasCheckedInPreviously {  get; set; }

        public UserRole Role { get; set; }
        public string Country {  get; set; }
    }
}
