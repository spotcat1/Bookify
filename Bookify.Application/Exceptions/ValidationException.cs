namespace Bookify.Application.Exceptions
{
    public sealed class ValidationException:Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Error = errors;
        }
        public IEnumerable<ValidationError> Error { get; }
    }
}
