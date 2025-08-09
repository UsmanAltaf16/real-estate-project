using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data.Configurations
{
    public class PropertyConfig : IEntityTypeConfiguration<Domain.Entities.Property>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Property> property)
        {
            property.ToTable("Properties");

            property.HasKey(x => x.Id);

            property.Property(x => x.Title).IsRequired().HasMaxLength(200);

            property.Property(x => x.Address).IsRequired().HasMaxLength(200);

            property.Property(x => x.ListingType).IsRequired().HasMaxLength(20); 

            property.Property(x => x.Price).HasColumnType("decimal(18,2)");

            property.Property(x => x.Bedrooms).HasDefaultValue(0);
            property.Property(x => x.Bathrooms).HasDefaultValue(0);
            property.Property(x => x.CarSpots).HasDefaultValue(0);

            property.Property(x => x.Description).HasMaxLength(2000);

            var converter = new ValueConverter<List<string>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>());

            var comparer = new ValueComparer<List<string>>(
                (l, r) => (l ?? new()).SequenceEqual(r ?? new()),
                v => v == null ? 0 : v.Aggregate(0, (a, s) => HashCode.Combine(a, s != null ? s.GetHashCode() : 0)),
                v => v == null ? new List<string>() : v.ToList());

            property.Property(x => x.ImageUrls).HasConversion(converter).Metadata.SetValueComparer(comparer);

            property.HasIndex(x => x.Price);
            property.HasIndex(x => x.Bedrooms);
            property.HasIndex(x => x.Bathrooms);
            property.HasIndex(x => x.Address);
            property.HasIndex(x => x.ListingType);
        }
    }
}
