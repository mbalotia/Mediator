using ClientMinimalAPI.Models;
using ClientMinimalAPI.Services;
using libCustomMediatR;

namespace ClientMinimalAPI.Handlers
{
    public class GetBookingHandler : IRequestHandler<GetBookingsQuery, List<Booking>>
    {
        readonly IBooking _booking;
        public GetBookingHandler(IBooking booking) {
            _booking = booking;        
        }      

        public Task<List<Booking>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_booking.GetBookings(request.Id));
           
        }
    }   
}
