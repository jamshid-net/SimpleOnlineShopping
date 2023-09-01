using Application.Common.Interfaces;
using Application.UseCases.Products.Reponse;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries;
public class GetProductByIdQuery:IRequest<ProductResponse>
{
    public int Id { get; set; }
}
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetProductByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
      var foundProduct = await _context.Products.Include(c=> c.Category).SingleOrDefaultAsync(product=> product.Id==request.Id,cancellationToken);
        if (foundProduct == null)
            throw new NotFoundException("Product", request.Id);

        var mappedProduct = _mapper.Map<ProductResponse>(foundProduct);
        return mappedProduct;

    }
}
