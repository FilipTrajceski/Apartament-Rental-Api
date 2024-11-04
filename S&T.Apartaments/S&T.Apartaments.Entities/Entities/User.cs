using Microsoft.AspNetCore.Identity;
using S_T.Apartaments.Entities.Enums;

namespace S_T.Apartaments.Entities.Entities
{
    public class User : IdentityUser
    {
        public UserRole Role { get; set; }
        public bool HasCheckedInPreviously {  get; set; }
    }
}
