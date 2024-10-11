using Bookify.Domain;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
    public sealed class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatuses =
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed,
        };

        public BookingRepository(ApplicationDbContext _context):base(_context) { }

        public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Booking>()
                .AnyAsync(booking => booking.ApartmentGuid == apartment.GUID &&
                booking.Duration.Start <= duration.End &&
                booking.Duration.End >= duration.Start &&
                ActiveBookingStatuses.Contains(booking.Status));
        }
    }
}
