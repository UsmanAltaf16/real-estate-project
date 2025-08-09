using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Application.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _repo;
    private readonly IMapper _mapper;

    public FavoriteService(IFavoriteRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // returns true if added, false if removed
    public async Task<bool> ToggleAsync(int userId, int propertyId)
    {
        var existing = await _repo.GetAsync(userId, propertyId);
        if (existing == null)
        {
            await _repo.AddAsync(new Domain.Entities.Favorite { UserId = userId, PropertyId = propertyId });
            await _repo.SaveChangesAsync();
            return true;
        }

        await _repo.RemoveAsync(existing);
        await _repo.SaveChangesAsync();
        return false;
    }

    public async Task<List<PropertyDto>> GetMineAsync(int userId)
    {
        var props = await _repo.GetUserFavoritesAsync(userId);
        return props.Select(p => _mapper.Map<PropertyDto>(p)).ToList();
    }
}
