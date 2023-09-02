using Application.Common.HelperExtentions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries;
public class GetProductsPaginationQuery:IRequest<Page<Product>>
{

}
public class GetProductsPaginationQueryHandler : IRequestHandler<GetProductsPaginationQuery, Page<Product>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Page<Product>> Handle(GetProductsPaginationQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
