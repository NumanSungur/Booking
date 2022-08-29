using Booking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("postgresql://zgrxtuqqizwmuihrdepzekrt%40psql-mock-database-cloud:nurxdqwtrmtsqxejtnaitbxb@psql-mock-database-cloud.postgres.database.azure.com:5432/booking1661672105070rxtbelutxtqdgsij");
        }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Appartments> Appartments { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
