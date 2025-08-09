using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public interface IPropertyRepository
    {
        IQueryable<Property> Query();
        Task<Property?> GetByIdAsync(int id);
    }
}
