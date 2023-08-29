using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories.Queries;
public class GetCategoryByIdQuery:IRequest<Category>
{
    public int Id { get; set; }
}
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var foundCategory = await _context.Categories
            .FindAsync(new object[] { request.Id },cancellationToken);

        if (foundCategory == null)
            throw new NotFoundException(nameof(Category), request.Id);

        return foundCategory;

    }
}
