using ClientMinimalAPI.Models;
using ClientMinimalAPI.Services;
using libCustomMediatR;

namespace ClientMinimalAPI.Handlers
{
    public class AddBookingHandler : IRequestHandler<AddBookingCommand, int>
    {
        readonly IBooking _booking;
        public AddBookingHandler(IBooking booking) {
            _booking = booking;        
        }      

        public async Task<int> Handle(AddBookingCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_booking.AddBooking(command.booking));          
           
        }
    }   
}
