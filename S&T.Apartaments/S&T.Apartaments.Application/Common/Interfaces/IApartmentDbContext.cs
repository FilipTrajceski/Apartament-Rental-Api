using Microsoft.EntityFrameworkCore;
using S_T.Apartaments.Entities.Entities;

namespace S_T.Apartaments.Application.Common.Interfaces
{
    public interface IApartmentDbContext
    {
        public DbSet<Apartment> Apartments {  get; }    
        public DbSet<Booking> Bookings { get; }

        public Task<int> SaveChangesAsync();
    }
}
