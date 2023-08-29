using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
     DbSet<Category> Categories { get; }

     DbSet<Order> Orders { get; }

     DbSet<Product> Products { get; set; }

     DbSet<ProductsOrder> ProductsOrders { get; }

     DbSet<User> Users { get; }
     Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}
