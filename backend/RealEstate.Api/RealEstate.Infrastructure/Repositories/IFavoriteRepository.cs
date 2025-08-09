using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<Favorite?> GetAsync(int userId, int propertyId);
        Task AddAsync(Favorite favorite);
        Task RemoveAsync(Favorite favorite);
        Task<List<Property>> GetUserFavoritesAsync(int userId);
        Task<int> SaveChangesAsync();
    }
}
