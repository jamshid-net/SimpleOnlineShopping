using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands;
public class CreateCategoryCommand : IRequest<int>
{
    public string CategoryName { get; set; }

}
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new Category()
        {
            CategoryName = request.CategoryName
        };

        await _context.Categories.AddAsync(category, cancellationToken);
       await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
