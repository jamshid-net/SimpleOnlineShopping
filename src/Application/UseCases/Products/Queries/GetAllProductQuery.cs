using Application.Common.Interfaces;
using Application.UseCases.Products.Reponse;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Products.Queries;
public class GetAllProductQuery:IRequest<List<ProductResponse>>
{}
public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public GetAllProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.Include(c=> c.Category).AsNoTracking().ToListAsync(cancellationToken);
        var mappedProducts = _mapper.Map<List<ProductResponse>>(products);
        return mappedProducts;
    }
}
