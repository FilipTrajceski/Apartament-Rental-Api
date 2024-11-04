using S_T.Apartaments.Entities.Enums;
using System.Collections.Specialized;

namespace S_T.Apartaments.Entities.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public Guid OwnerId {  get; set; }
        public string OwnerName {  get; set; }
        public Guid? RenterId {  get; set; }
        public string Address {  get; set; }
        public string Description {  get; set; }
        public ApartmentSize ApartmentSize {  get; set; }
        public ApartmentStatus ApartmentStatus {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}

        //navigation property
        public User User { get; set; }
    }
}
