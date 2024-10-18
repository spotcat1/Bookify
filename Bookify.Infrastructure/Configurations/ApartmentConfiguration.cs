using Bookify.Domain.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("apartments");

            builder.HasKey(a => a.GUID);

            builder.OwnsOne(a => a.Address);

            builder.Property(a => a.Name).HasMaxLength(200)
                .HasConversion(n => n.Value, v => new Name(v));

            builder.Property(a => a.Description).HasMaxLength(2000)
                .HasConversion(d => d.Value, v => new Description(v));

            builder.OwnsOne(a => a.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                .HasConversion(c => c.Code, c => Currency.FromCode(c));
            });

            builder.OwnsOne(a => a.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                .HasConversion(c => c.Code, c => Currency.FromCode(c));
            });

            builder.Property<uint>("Version").IsRowVersion();
        }
    }
}
