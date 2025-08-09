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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");

            user.HasKey(t => t.Id);

            user.Property(x => x.Email).IsRequired().HasMaxLength(256);

            user.HasIndex(x => x.Email).IsUnique();

            user.Property(x => x.PasswordHash).IsRequired().HasMaxLength(512);

        }
    }
}
