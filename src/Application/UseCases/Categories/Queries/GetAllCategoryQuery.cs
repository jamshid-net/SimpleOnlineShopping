using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories.Queries;
public class GetAllCategoryQuery:IRequest<IQueryable<Category>>
{ }
public class GetAllCategoryQueryHandler : 
    IRequestHandler<GetAllCategoryQuery, IQueryable<Category>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<Category>> 
        Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = _context.Categories.AsNoTracking().AsQueryable();

        return await Task.FromResult(categories);
    }
}
