using DemoServerApi.Data;

namespace DemoServerApi.Models
{
    public static class DataSeeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var users = new List<User>
        {
            new User { FullName = "John Doe", Email = "john@example.com" },
            // Add more users if needed
        };

            var bookings = new List<Booking>
        {
            new Booking { UserId = 1, BookingDate = DateTime.Now.AddDays(7) },
            // Add more bookings if needed
        };

            context.Users.AddRange(users);
            context.Bookings.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
