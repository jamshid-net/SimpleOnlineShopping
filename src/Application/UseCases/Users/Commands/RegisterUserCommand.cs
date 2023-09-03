using Application.Common.HelperExtentions;
using Application.Common.Interfaces;
using Application.Common.JWT;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Users.Commands;
public class RegisterUserCommand:IRequest<TokenResponse>
{
    public string FullName { get; set; } 
    public string Phone { get; set; } 
    public string Password { get; set; }
    public string Email { get; set; }
    public string? ShortAddress { get; set; }
    
}
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TokenResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IJwtToken _jwtToken;
    public RegisterUserCommandHandler(IApplicationDbContext context, IMapper mapper, IJwtToken jwtToken)
    {
        _context = context;
        _mapper = mapper;
        _jwtToken = jwtToken;
    }

    public async Task<TokenResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var isExistsEmail = _context.Users.Any(x => x.Email == request.Email);
        if (isExistsEmail) 
            throw new AlreadyExistsException("User",request.Email);

        string hashedPassowrd = request.Password.GetHashedString();
        var newUser = _mapper.Map<User>(request);

        var defaultRole = _context.Roles.FirstOrDefault(r => r.RoleName == "user");
        newUser.Roles.Add(defaultRole);

        newUser.Password = hashedPassowrd;
        await _context.Users.AddAsync(newUser, cancellationToken);
        if( await _context.SaveChangesAsync(cancellationToken)>0)
        {
            return await _jwtToken.GenerateTokenAsync(newUser.Id, newUser.Email,newUser.Roles);
        }
        else
        {
            return new TokenResponse { AccessToken = "No token" };
        }
    }
}
