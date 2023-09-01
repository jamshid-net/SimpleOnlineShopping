using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Commands;
public class DeleteUserCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser=await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        if (foundUser == null)
            throw new NotFoundException("User is not found", request.Id);

        _context.Users.Remove(foundUser);
       await _context.SaveChangesAsync(cancellationToken);

    }
}
