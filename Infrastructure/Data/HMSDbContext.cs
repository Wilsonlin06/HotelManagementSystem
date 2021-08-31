using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HMSDbContext : DbContext
    {
        // Inject the ConnectionString
        public HMSDbContext(DbContextOptions<HMSDbContext> options) : base(options)
        {

        }

        // Creating the database using EF Core
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<_Service> Services { get; set; }

    }
}
