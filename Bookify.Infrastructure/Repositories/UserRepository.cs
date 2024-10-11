
using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context):base(_context)
        { 
        }
    }
}
