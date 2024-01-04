using libCustomMediatR;

namespace ClientMinimalAPI.Handlers
{
    public record GetBookingsQuery(int Id) : IRequest<List<Booking>>;
   
}
