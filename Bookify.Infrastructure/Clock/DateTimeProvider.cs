using Bookify.Application.Abstractions.Clocks;

namespace Bookify.Infrastructure.Clock
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime utcNow => DateTime.UtcNow;
    }
}
