using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data.Configurations
{
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> b)
        {
            b.ToTable("Favorites");

            b.HasKey(x => new { x.UserId, x.PropertyId });

            b.HasOne(x => x.User).WithMany(u => u.Favorites).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            b.HasOne(x => x.Property).WithMany(p => p.Favorites).HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(x => x.PropertyId);
        }
    }
}
