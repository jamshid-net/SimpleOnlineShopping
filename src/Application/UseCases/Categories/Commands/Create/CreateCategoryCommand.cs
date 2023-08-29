
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands.Create;
public class CreateCategoryCommand:IRequest<bool>
{
    public string CategoryName { get; set; }

}
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(new Category() { CategoryName = request.CategoryName },cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
            
    }
}
