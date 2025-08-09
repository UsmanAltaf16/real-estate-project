using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppDbContext _db;

    public PropertyRepository(AppDbContext db) => _db = db;

    public IQueryable<Property> Query() => _db.Properties.AsNoTracking();

    public Task<Property?> GetByIdAsync(int id)
        => _db.Properties.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
}
