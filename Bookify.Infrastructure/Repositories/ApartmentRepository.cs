﻿using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories
{
    public sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
