using Microsoft.AspNetCore.Identity;
using S_T.Apartaments.Entities.Enums;
using System.Text.Json.Serialization;

namespace S_T.Apartaments.Entities.Entities
{
    public class User : IdentityUser
    {
        public UserRole Role { get; set; }
        public bool HasCheckedInPreviously {  get; set; }
        public string Country {  get; set; }

        //navigation property
        [JsonIgnore]
        public ICollection<Apartment> Apartment { get; set; }
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}
