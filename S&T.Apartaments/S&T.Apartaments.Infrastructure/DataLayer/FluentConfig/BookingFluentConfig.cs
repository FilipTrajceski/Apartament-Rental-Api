using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S_T.Apartaments.Entities.Entities;

namespace S_T.Apartaments.Infrastructure.DataLayer.FluentConfig
{
    internal class BookingFluentConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.BookingId);

            builder.HasOne(x => x.Apartment)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(r => r.RenterId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.StartDate)
                .IsRequired();
            builder.Property(x => x.EndDate)
                .IsRequired();

            builder.HasIndex(x => x.CreatedAt);
        }
    }
}
