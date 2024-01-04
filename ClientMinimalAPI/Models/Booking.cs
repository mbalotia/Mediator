using libCustomMediatR;

namespace ClientMinimalAPI
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string? FromDestination { get; set; }
        public string? ToDestination { get; set; }
     
    }

    public class BookingRequest : IRequest<List<Booking>>
    {
        public int BookingId { get; set; }
    }
}
