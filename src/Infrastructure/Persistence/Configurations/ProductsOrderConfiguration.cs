using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
public class ProductsOrderConfiguration : IEntityTypeConfiguration<ProductsOrder>
{
    public void Configure(EntityTypeBuilder<ProductsOrder> entity)
    {

        entity
            .HasNoKey()
            .ToTable("products_orders");

        entity.Property(e => e.OrderId).HasColumnName("order_id");
        entity.Property(e => e.ProductId).HasColumnName("product_id");

        entity.HasOne(d => d.Order).WithMany()
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("products_orders_order_id_fkey");

        entity.HasOne(d => d.Product).WithMany()
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("products_orders_product_id_fkey");

    }
}
