using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings.Events;


namespace Bookify.Domain.Bookings
{
    public sealed class Booking : Entity
    {
        private Booking(Guid Guid,
            Guid apartmentGuid,
            Guid userGuid,
            DateRange duration,
            Money priceForPeriod,
            Money cleaningFee, 
            Money amenitiesUpCharge, 
            Money totalPrice,
            BookingStatus status, 
            DateTime createdOnUtc) : base(Guid)
        {
            ApartmentGuid = apartmentGuid;
            UserGuid = userGuid;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            CleaningFee = cleaningFee;
            AmenitiesUpCharge = amenitiesUpCharge;
            TotalPrice = totalPrice;
            Status = status;
            CreatedOnUtc = createdOnUtc;
            
        }

        public Guid ApartmentGuid { get; private set; }
        public Guid UserGuid { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ConfirmedOnUtc { get; private set; }
        public DateTime? RejectedOnUtc { get; private set; }
        public DateTime? CompletedOnUtc { get; private set; }
        public DateTime? CancelledOnUtc { get; private set; }


        public static Booking Reserver(Apartment apartment,
            Guid userGuid,
            DateRange duration,
            DateTime utcNow,
            PricingServices pricingServices)
        {
            PricingDetails pricingDetails = pricingServices.CalculatePrice(apartment, duration);

            var booking = new Booking(
                Guid.NewGuid(),
                apartment.GUID,
                userGuid,
                duration,
                pricingDetails.PriceForPeriod,
                pricingDetails.CleaningFee,
                pricingDetails.AmenitiesUpCHarge,
                pricingDetails.TotalPrice,
                BookingStatus.Reserved,
                utcNow);


            booking.RaiseDomainEvents(new BookingReservedDomainEvent(booking.GUID));

            apartment.LastBookedOnUtc = utcNow;

            return booking;
        }


    }
}

