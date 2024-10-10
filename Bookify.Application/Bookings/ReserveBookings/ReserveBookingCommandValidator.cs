using Bookify.Application.ReserveBookings;
using FluentValidation;

namespace Bookify.Application.Bookings.ReserveBookings
{
    internal sealed class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(c => c.ApartmentGuid).NotEmpty();

            RuleFor(c => c.UserGuid).NotEmpty();

            RuleFor(c => c.StartDate).LessThan(c => c.EndDate).NotEmpty();
        }
    }
}
