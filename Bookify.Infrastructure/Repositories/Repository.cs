using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
    public abstract class Repository<T> 
        where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid Guid, 
            CancellationToken cancellationToken = default)
        {
            return await _context
                .Set<T>()
                .FirstOrDefaultAsync(_ => _.GUID == Guid, cancellationToken);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }
    }
}
