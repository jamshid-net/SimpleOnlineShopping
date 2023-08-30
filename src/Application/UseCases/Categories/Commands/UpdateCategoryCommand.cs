using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories.Commands;
public class UpdateCategoryCommand:IRequest
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
}
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
       var foundCategory =await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
        if (foundCategory == null)
            throw new NotFoundException(nameof(Category), request.Id);

        foundCategory.CategoryName = request.CategoryName;

        await _context.SaveChangesAsync(cancellationToken);
        
    }
}
