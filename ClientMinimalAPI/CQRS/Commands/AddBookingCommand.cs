using libCustomMediatR;

namespace ClientMinimalAPI.Handlers
{
    public record AddBookingCommand(Booking booking): IRequest<int>;
    
}