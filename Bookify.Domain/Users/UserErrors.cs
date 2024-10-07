using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new(
        "User.Found",
        "The User was not found");
    }
}
