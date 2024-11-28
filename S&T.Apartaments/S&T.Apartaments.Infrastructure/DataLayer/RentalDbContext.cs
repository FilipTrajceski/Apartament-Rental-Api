using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Entities.Entities;

namespace S_T.Apartaments.Infrastructure.DataLayer
{
    public class RentalDbContext : IdentityDbContext<User>,IApartmentDbContext
    {
        public DbSet<Apartment> Apartments => Set<Apartment>();

        public DbSet<Booking> Bookings => Set<Booking>();   

        public RentalDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-52E2U68\\SQLEXPRESS;Database=ApartmentRental;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(RentalDbContext).Assembly);
            base.OnModelCreating(builder);
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
