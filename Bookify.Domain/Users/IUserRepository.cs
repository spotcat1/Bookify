namespace Bookify.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid Guid, CancellationToken cancellationToken = default);

        void Add(User user);
    }
}
