using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.Id).HasName("users_pkey");

        entity.ToTable("users");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.BirthDate).HasColumnName("birth_date");
        entity.Property(e => e.Email).HasColumnName("email");
        entity.Property(e => e.FullName).HasColumnName("full_name");
        entity.Property(e => e.Password).HasColumnName("password");
        entity.Property(e => e.Phone)
            .HasMaxLength(12)
            .HasColumnName("phone");
        entity.Property(e => e.ShortAddress).HasColumnName("short_address");
        entity.Property(e => e.UserPicture).HasColumnName("user_picture");
    }
}
