using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories.Commands;
public class DeleteCategoryCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var foundCategory = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
        if (foundCategory == null)
            throw new NotFoundException(nameof(Category), request.Id);

        _context.Categories.Remove(foundCategory);
        await _context.SaveChangesAsync(cancellationToken);

    }
 
}
