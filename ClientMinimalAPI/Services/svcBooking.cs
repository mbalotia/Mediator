
using Microsoft.EntityFrameworkCore;

namespace ClientMinimalAPI.Services
{
    public class svcBooking : IBooking
    {
        public svcBooking()
        {
            using var ctx = new BookingDbContext();
            var bookings = new List<Booking>
                {
                    new() { BookingDate = DateTime.Now, BookingId = 1, FromDate = new DateOnly(2024, 02, 05), ToDate = new DateOnly(2024, 02, 08), FromDestination = "EWR", ToDestination = "YYZ" },
                    new() { BookingDate = DateTime.Now, BookingId = 2, FromDate = new DateOnly(2024, 04, 15), ToDate = new DateOnly(2024, 04, 20), FromDestination = "PHL", ToDestination = "CUN" }
                };
            ctx.Bookings.AddRange(bookings);
            ctx.SaveChanges();
        }
        public int AddBooking(Booking booking)
        {
            using var ctx = new BookingDbContext();
            ctx.Bookings.Add(booking);
            ctx.SaveChanges();
            return booking.BookingId;
        }

        public List<Booking> GetBookings(int Id)
        {
            using var ctx = new BookingDbContext();
            return ctx.Bookings.Where(a => a.BookingId == Id).ToList();
        }
    }
}
