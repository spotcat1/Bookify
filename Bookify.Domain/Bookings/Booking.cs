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

        private Booking()
        {
            
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


        public static Booking Reserver(
            Apartment apartment,
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


        public Result Confirm (DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Confirmed;
            ConfirmedOnUtc = utcNow;


            RaiseDomainEvents(new BookingConfirmedDomainEvent(GUID));

            return Result.Success();
        }


        public Result Reject(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Rejected;
            RejectedOnUtc = utcNow;


            RaiseDomainEvents(new BookingRejectedDomainEvent(GUID));

            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.NotConfirmed);
            }

            Status = BookingStatus.Completed;
            CompletedOnUtc = utcNow;


            RaiseDomainEvents(new BookingCompletedDomainEvent(GUID));

            return Result.Success();
        }


        public Result Cancel(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start)
            {
                return Result.Failure(BookingErrors.AlreadyStarted);
            }

            Status = BookingStatus.Cancelled;
            CancelledOnUtc = utcNow;


            RaiseDomainEvents(new BookingCancelledDomainEvent(GUID));

            return Result.Success();
        }
    }
}

