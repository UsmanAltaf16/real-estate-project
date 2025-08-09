using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RealEstate.Domain.Entities.User> Users => Set<RealEstate.Domain.Entities.User>();
        public DbSet<RealEstate.Domain.Entities.Property> Properties => Set<RealEstate.Domain.Entities.Property>();
        public DbSet<RealEstate.Domain.Entities.Favorite> Favorites => Set<RealEstate.Domain.Entities.Favorite>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
