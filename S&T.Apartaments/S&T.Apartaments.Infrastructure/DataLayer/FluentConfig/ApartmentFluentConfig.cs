using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S_T.Apartaments.Entities.Entities;

namespace S_T.Apartaments.Infrastructure.DataLayer.FluentConfig
{
    public class ApartmentFluentConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.ApartmentId);

            builder.HasOne(x => x.User)
                .WithMany(x=>x.Apartment)
                .HasForeignKey(x =>x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Address).IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CreatedDate)
                .IsRequired();
            builder.HasIndex(e => e.CreatedDate);
        }
    }
}
