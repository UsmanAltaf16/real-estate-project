using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class AuthRepository<T> : IAuthRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> _set;

    public AuthRepository(AppDbContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        => _set.FirstOrDefaultAsync(predicate);

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => _set.AnyAsync(predicate);

    public async Task<T> AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        return entity;
    }

    public Task<int> SaveChangesAsync()
        => _db.SaveChangesAsync();
}
