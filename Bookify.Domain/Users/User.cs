using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;


namespace Bookify.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid Guid, FirstName firstName, LastName lastName, Email email) : base(Guid)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }



        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }

        public static User Create(FirstName FirstName, LastName LastName, Email Email)
        {
            var user = new User(Guid.NewGuid(), FirstName, LastName, Email);

            user.RaiseDomainEvents(new UserCreatedDomainEvent(user.GUID));

            return user;
        }
    }
}
