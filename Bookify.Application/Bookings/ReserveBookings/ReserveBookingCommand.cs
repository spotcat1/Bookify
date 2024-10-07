using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;

namespace Bookify.Application.ReserveBookings
{
    internal sealed record ReserveBookingCommand
        (Guid UserGuid,
        Guid ApartmentGuid,
        DateOnly StartDate,
        DateOnly EndDate
        ):ICommand<Guid>
    {
    }
}
