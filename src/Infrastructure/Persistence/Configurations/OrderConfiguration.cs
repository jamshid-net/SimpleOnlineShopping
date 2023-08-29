using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(e => e.Id).HasName("orders_pkey");

        entity.ToTable("orders");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.OrderDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("order_date");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.User).WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("orders_user_id_fkey");
    }
}
