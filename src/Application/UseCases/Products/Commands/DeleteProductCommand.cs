using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Products.Commands;
public class DeleteProductCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var foundProduct =await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
        if (foundProduct == null)
            throw new NotFoundException("Product", request.Id);
        _context.Products.Remove(foundProduct);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
