using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(e => e.Id).HasName("category_pkey");

        entity.ToTable("categories");

        entity.Property(e => e.Id)
            .HasDefaultValueSql("nextval('category_id_seq'::regclass)")
            .HasColumnName("id");
        entity.Property(e => e.CategoryName)
            .HasMaxLength(20)
            .HasColumnName("category_name");
    }
}
