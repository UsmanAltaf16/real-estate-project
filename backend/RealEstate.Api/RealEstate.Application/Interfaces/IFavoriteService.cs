using RealEstate.Application.DTOs.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> ToggleAsync(int userId, int propertyId);
        Task<List<PropertyDto>> GetMineAsync(int userId);
    }
}
