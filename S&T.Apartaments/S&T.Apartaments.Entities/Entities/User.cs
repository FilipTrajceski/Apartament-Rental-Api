using Microsoft.AspNetCore.Identity;

namespace S_T.Apartaments.Entities.Entities
{
    public class User : IdentityUser
    {
        public bool HasCheckedInPreviously {  get; set; }
    }
}
