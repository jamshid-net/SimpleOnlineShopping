using Application.Common.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Commands;
public class LoginUserCommand:IRequest<TokenResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }    
}
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponse>
{
    private readonly IJwtToken _jwtToken;

    public LoginUserCommandHandler(IJwtToken jwtToken)
    {
        _jwtToken = jwtToken;
    }

    public async Task<TokenResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _jwtToken.AuthenAsync(request);
        
        if (user != null || !string.IsNullOrEmpty(user.Email))
        {
            return await _jwtToken.GenerateTokenAsync(user.Id, user.Email, user.Roles);

        }
        else
          return new TokenResponse() { AccessToken = "No token" };
    }
}
