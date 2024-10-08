using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.GetBooking
{
    public sealed record GetBookingByIdQuery(int BookingId) :IQuery<BookingResponse>;
}
