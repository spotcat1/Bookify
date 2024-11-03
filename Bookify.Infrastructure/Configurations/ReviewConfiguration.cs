using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Review;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ReviewConfiguration:IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");

            builder.HasKey(review => review.GUID);

            builder.Property(review => review.Rating)
                .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

            builder.Property(review => review.Comment)
                .HasMaxLength(200)
                .HasConversion(comment => comment.Value, value => new Comment(value));

            builder.HasOne<Apartment>()
                .WithMany()
                .HasForeignKey(review => review.ApartmentGuid)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Booking>()
                .WithMany()
                .HasForeignKey(review => review.BookingGuid)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(review => review.UserGuid)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
