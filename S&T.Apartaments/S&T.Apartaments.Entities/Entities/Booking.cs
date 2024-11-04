using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Entities.Entities
{
    public class Booking
    {
        public int BookingId {  get; set; }
        public Guid RenterId {  get; set; }
        public int ApartmentId {  get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public BookingStatus BookingStatus {  get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set;}

        //navigational properties
        public User User { get; set; }
        public Apartment Apartment { get; set; }
    }
}
