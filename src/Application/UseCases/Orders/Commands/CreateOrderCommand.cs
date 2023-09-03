using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Orders.Commands;
public class CreateOrderCommand:IRequest<int>
{
    public int[] ProductIds { get; set; } = null!;
}
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{   
    private readonly ICurrentUser _currentUser;

    private readonly IApplicationDbContext _context;
    public CreateOrderCommandHandler(ICurrentUser currentUser, IApplicationDbContext context)
    {
        _currentUser = currentUser;
        _context = context;
    }


    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderedProducts = new List<Product>();

        var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

        products.ForEach(product =>
        {
            if (request.ProductIds.Any(id => id == product.Id))
                orderedProducts.Add(product);
        });

        if(!int.TryParse(_currentUser.Id,out int userid))
        {
            throw new NotFoundException("User is not found");
        }
        Order order = new Order()
        {
            UserId = userid,
            Products = orderedProducts,
            OrderDate = DateTime.Now,
        };

        await _context.Orders.AddAsync(order);
       await _context.SaveChangesAsync(cancellationToken);
        return order.Id;
    }
}
