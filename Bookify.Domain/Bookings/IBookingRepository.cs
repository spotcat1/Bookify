using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings
{
    public interface IBookingRepository
    {
        Task<bool> IsOverLappingAsync(DateRange duration, Apartment apartment, CancellationToken cancellationToken = default);
        Task<Booking> GetByIdAsync(Guid bookingGuid, CancellationToken cancellationToken = default);
        void Add(Booking booking);
    }
}
