using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.UserDto
{
    public class ChangeUserRoleDto
    {
        public string Username { get; set; }
        public UserRole CurrentRole {  get; set; }
        public UserRole ChangeRoleTo {  get; set; }

    }
}
