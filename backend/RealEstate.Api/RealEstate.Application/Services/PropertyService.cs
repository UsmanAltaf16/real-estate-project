using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.DTOs.Common;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _repo;
    private readonly IMapper _mapper;

    public PropertyService(IPropertyRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PagedResult<PropertyDto>> SearchAsync(PropertySearchRequest rq)
    {
        var query = _repo.Query();

        if (rq.MinPrice.HasValue) query = query.Where(p => p.Price >= rq.MinPrice.Value);
        if (rq.MaxPrice.HasValue) query = query.Where(p => p.Price <= rq.MaxPrice.Value);
        if (rq.Bedrooms.HasValue) query = query.Where(p => p.Bedrooms >= rq.Bedrooms.Value);
        if (rq.Bathrooms.HasValue) query = query.Where(p => p.Bathrooms >= rq.Bathrooms.Value);
        if (!string.IsNullOrWhiteSpace(rq.Suburb))
            query = query.Where(p => p.Address.Contains(rq.Suburb!));
        if (!string.IsNullOrWhiteSpace(rq.ListingType))
            query = query.Where(p => p.ListingType == rq.ListingType);
        if (!string.IsNullOrWhiteSpace(rq.Q))
            query = query.Where(p => p.Title.Contains(rq.Q!) || p.Description.Contains(rq.Q!));

        var total = await query.CountAsync();

        var page = rq.Page <= 0 ? 1 : rq.Page;
        var size = rq.PageSize <= 0 ? 12 : rq.PageSize;

        var items = await query
            .OrderBy(p => p.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResult<PropertyDto> { Items = items, Total = total, Page = page, PageSize = size };
    }

    public async Task<PropertyDto?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<PropertyDto>(entity);
    }
}
