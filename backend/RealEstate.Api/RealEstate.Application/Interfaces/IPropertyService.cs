using RealEstate.Application.DTOs.Common;
using RealEstate.Application.DTOs.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<PagedResult<PropertyDto>> SearchAsync(PropertySearchRequest request);
        Task<PropertyDto?> GetByIdAsync(int id);
    }
}
