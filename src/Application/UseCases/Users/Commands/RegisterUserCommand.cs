

using Application.Common.Interfaces;
using Application.Common.JWT;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Users.Commands;
public class RegisterUserCommand:IRequest<TokenResponse>
{
    public string FullName { get; set; } 
    public DateOnly? BirthDate { get; set; }
    public string Phone { get; set; } 
    public string Password { get; set; }
    public string Email { get; set; }
    public string? ShortAddress { get; set; }
    public string? UserPicture { get; set; }
}
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TokenResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    Task<TokenResponse> IRequestHandler<RegisterUserCommand, TokenResponse>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
