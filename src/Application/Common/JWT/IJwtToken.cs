using Application.UseCases.Users.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.JWT;
public interface IJwtToken
{
    Task<TokenResponse> GenerateTokenAsync(int userId, string email, List<Role> roles);
    Task<User> AuthenAsync(LoginUserCommand user);


}
