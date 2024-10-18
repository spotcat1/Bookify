using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.ReserveBookings
{
    public sealed record ReserveBookingCommand
        (Guid UserGuid,
        Guid ApartmentGuid,
        DateOnly StartDate,
        DateOnly EndDate
        ) : ICommand<Guid>
    {
    }
}
