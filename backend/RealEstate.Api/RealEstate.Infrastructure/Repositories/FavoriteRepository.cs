using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly AppDbContext _db;

    public FavoriteRepository(AppDbContext db) => _db = db;

    public Task<Favorite?> GetAsync(int userId, int propertyId)
        => _db.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);

    public async Task AddAsync(Favorite favorite)
        => await _db.Favorites.AddAsync(favorite);

    public Task RemoveAsync(Favorite favorite)
    {
        _db.Favorites.Remove(favorite);
        return Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync()
        => _db.SaveChangesAsync();

    public async Task<List<Property>> GetUserFavoritesAsync(int userId)
    {
        var query = from f in _db.Favorites
                    join p in _db.Properties on f.PropertyId equals p.Id
                    where f.UserId == userId
                    select p;

        return await query.AsNoTracking().ToListAsync();
    }
}
