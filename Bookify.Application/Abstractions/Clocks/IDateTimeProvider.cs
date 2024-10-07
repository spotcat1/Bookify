namespace Bookify.Application.Abstractions.Clocks
{
    public interface IDateTimeProvider
    {
        DateTime utcNow { get; }    
    }
}
