using Bookify.Application.Abstractions.Emails;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.ReserveBookings
{
    internal sealed class BookingReservedEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingGuid,cancellationToken);

            if (booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserGuid, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync
                (user.Email,
                "Booking Reserved",
                "You have 10 minutes to confirm the booking");
        }
    }
}
