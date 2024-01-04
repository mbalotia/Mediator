namespace ClientMinimalAPI.Services
{
    public interface IBooking
    {
        public List<Booking> GetBookings(int Id);

        public int AddBooking(Booking booking);
    }
}
