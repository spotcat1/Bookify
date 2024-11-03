using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class BookingConfiguratin : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");

            builder.HasKey(booking => booking.GUID);

            builder.OwnsOne(booking => booking.PriceForPeriod, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                    .HasPrecision(18, 2);
            });

            builder.OwnsOne(booking => booking.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                   .HasPrecision(18, 2);
            });

            builder.OwnsOne(booking => booking.AmenitiesUpCharge, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                   .HasPrecision(18, 2);
            });

            builder.OwnsOne(booking => booking.TotalPrice, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                priceBuilder.Property(money => money.Amount)
                   .HasPrecision(18, 2);
            });

            builder.OwnsOne(booking => booking.Duration);

            builder.HasOne<Apartment>()
                .WithMany()
                .HasForeignKey(booking => booking.ApartmentGuid);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(booking => booking.UserGuid);
        }
    }
}
