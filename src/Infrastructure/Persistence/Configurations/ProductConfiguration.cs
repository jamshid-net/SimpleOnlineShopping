using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(e => e.Id).HasName("product_pkey");

        entity.ToTable("products");

        entity.Property(e => e.Id)
            .HasDefaultValueSql("nextval('product_id_seq'::regclass)")
            .HasColumnName("id");
        entity.Property(e => e.CategoryId).HasColumnName("category_id");
        entity.Property(e => e.ProductName)
            .HasMaxLength(30)
            .HasColumnName("product_name");
        entity.Property(e => e.ProductPicture).HasColumnName("product_picture");
        entity.Property(e => e.ProductPrice).HasColumnName("product_price");

        entity.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("product_category_id_fkey");
    }
}
