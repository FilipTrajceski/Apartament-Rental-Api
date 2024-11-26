using S_T.Apartaments.Entities.Enums;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace S_T.Apartaments.Entities.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string OwnerId {  get; set; }
        public string OwnerName {  get; set; }
        public string? RenterId {  get; set; }
        public string RenterName { get; set; }
        public string Address {  get; set; }
        public string Description {  get; set; }
        public ApartmentSize ApartmentSize {  get; set; }
        public ApartmentStatus ApartmentStatus {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}

        //navigation property
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}
