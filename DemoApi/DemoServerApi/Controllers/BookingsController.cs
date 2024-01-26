using DemoServerApi.Data;
using DemoServerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoServerApi.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings.ToList();
            return Ok(bookings);
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] Booking updatedBooking)
        {
            var existingBooking = _context.Bookings.Find(id);

            if (existingBooking == null)
            {
                return NotFound();
            }

            existingBooking.UserId = updatedBooking.UserId;
            existingBooking.BookingDate = updatedBooking.BookingDate;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
