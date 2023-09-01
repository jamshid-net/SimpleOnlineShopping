using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Commands;
public class UpdateProductCommand:IRequest
{
    public int Id { get; set; }

    public string ProductName { get; set; } 

    public float ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public int? CategoryId { get; set; }
}
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
  
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
   
    }
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var foundProduct =await _context.Products.FindAsync(new object[] { request.Id },cancellationToken);
        if (foundProduct == null)
            throw new NotFoundException("Produuct", request.Id);

        foundProduct.ProductName = request.ProductName;
        foundProduct.ProductPrice = request.ProductPrice;
        foundProduct.ProductPicture = request.ProductPicture;
        foundProduct.CategoryId = request.CategoryId;
      
       
        await _context.SaveChangesAsync(cancellationToken);

    }
}

