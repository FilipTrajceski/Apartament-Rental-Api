using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S_T.Apartaments.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Infrastructure.DataLayer.FluentConfig
{
    public class UserFluentConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Bookings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired().HasMaxLength(256);

            var hasher = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@adminsky.com",
                    NormalizedEmail = "ADMIN@ADMINSKY.COM",
                    EmailConfirmed = true,
                    Country = "USA",
                    Role = Entities.Enums.UserRole.Admin,
                    HasCheckedInPreviously = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")


                }

                );
        }
    }
}
