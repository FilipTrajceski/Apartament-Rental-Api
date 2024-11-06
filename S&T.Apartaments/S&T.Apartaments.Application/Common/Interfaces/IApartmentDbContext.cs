using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using S_T.Apartaments.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.Interfaces
{
    public interface IApartmentDbContext
    {
        public DbSet<Apartment> Apartments {  get; }    
        public DbSet<Booking> Bookings { get; }

        public Task<int> SaveChangesAsync();
    }
}
