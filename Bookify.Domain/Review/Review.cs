using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Bookify.Domain.Review.Events;
using System.Xml.Linq;

namespace Bookify.Domain.Review
{
    public sealed class Review : Entity
    {
        private Review(Guid Guid, Guid apartmentGuid,
        Guid bookingGuid,
        Guid userGuid,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc) : base(Guid)
        {

        }


        public Guid ApartmentGuid { get; private set; }

        public Guid BookingGuid { get; private set; }

        public Guid UserGuid { get; private set; }

        public Rating Rating { get; private set; }

        public Comment Comment { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }




        public static Result<Review> Create(
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
        {
            if (booking.Status != BookingStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotEligible);
            }

            var review = new Review(
                Guid.NewGuid(),
                booking.ApartmentGuid,
                booking.GUID,
                booking.UserGuid,
                rating,
                comment,
                createdOnUtc);

            review.RaiseDomainEvents(new ReviewCreatedDomainEvent(review.GUID));

            return review;
        }
    }
}
