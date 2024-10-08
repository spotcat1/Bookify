using Bookify.Domain;

namespace Bookify.Application.Bookings.GetBooking
{
    public sealed class BookingResponse
    {
        public Guid GUID { get; init; }
        public Guid ApartmentGuid { get; init; }
        public Guid UserGuid { get; init; }
        public DateRange Duration { get; init; }
        public decimal PriceAmount { get; init; }
        public string PriceCurrency { get; init; }
        public decimal CleaningFeeAmount { get; init; }
        public string CleaningFeeCurrency { get; init; }
        public decimal AmenitiesUpChargeAmount { get; init; }
        public string AmenitiesUpChargeCurrency { get; init; }
        public decimal TotalPriceAmount { get; init; }
        public decimal TotalPriceCurrency { get; init; }
        public DateTime CreatedOnUtc { get; init; }
        public DateTime DurationStart { get; init; }
        public DateTime DurationEnd { get; init; }
    }
}