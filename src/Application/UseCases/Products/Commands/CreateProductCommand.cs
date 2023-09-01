using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Commands;
public class CreateProductCommand:IRequest<int>
{
    public string ProductName { get; set; }
    public float ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public int? CategoryId { get; set; }

}
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<Product>(request);
        await _context.Products.AddAsync(newProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return newProduct.Id;
        
    }
}
