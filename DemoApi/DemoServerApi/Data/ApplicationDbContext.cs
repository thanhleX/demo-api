using DemoServerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoServerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
