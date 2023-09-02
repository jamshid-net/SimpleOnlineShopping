using Application.Common.HelperExtentions;
using Application.Common.Interfaces;
using Application.UseCases.Products.Reponse;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagination.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries;
public class GetProductsPaginationQuery:IRequest<Pagination<ProductResponse>>
{
    public int Page { get; set; }
    public int Limit { get; set; }
    public string? OrderByColumn { get; set; } = "";
    public bool OrderByDescending { get; set; } = false;

}
public class GetProductsPaginationQueryHandler : IRequestHandler<GetProductsPaginationQuery, Pagination<ProductResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetProductsPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Pagination<ProductResponse>> Handle(GetProductsPaginationQuery request, CancellationToken cancellationToken)
    {
        var paginatedProducts = await _context.Products
            .AsNoTracking().Include(c => c.Category).
            AsPaginationAsync(request.Page, request.Limit, request.OrderByColumn, request.OrderByDescending);
        var mappedProducts = _mapper.Map<Pagination<ProductResponse>>(paginatedProducts);
        return mappedProducts;
    }
}
