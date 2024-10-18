namespace Bookify.Api.Controllers.Bookings
{
    public sealed record AddBookingRequest(Guid ApartmentGuid,
        Guid UserGuid,
        DateOnly StartDate,
        DateOnly EndDate);
    
}