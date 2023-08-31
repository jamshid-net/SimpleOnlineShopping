
using Application.Common.HelperExtentions;
using Application.Common.Interfaces;
using Application.UseCases.Users.Commands;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Common.JWT;
public class JwtToken : IJwtToken
{

    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _context;

    public JwtToken(IConfiguration configuration, IApplicationDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<User> AuthenAsync(LoginUserCommand user)
    {
        var hashedPassword = user.Password.GetHashedString();

        var foundUser =await _context.Users
            .SingleOrDefaultAsync(x=> x.Email == user.Email && x.Password == hashedPassword);
        if(foundUser == null || string.IsNullOrEmpty(foundUser.Email))
        {
            throw new NotFoundException("User not found", user.Email);
          
        }
        return foundUser;
       
    }

    public async Task<TokenResponse> GenerateTokenAsync(int userId, string email, string[] roles)
    {
        var claims = new List<Claim>()
        {
            new Claim("Email", email),
            new Claim("UserId",userId.ToString())

        };

        if (roles.Length > 0)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim("Roles", role));
            }
        }
        var jwt = new JwtSecurityToken(
               issuer: _configuration.GetValue<string>("JWT:Issuer"),
               audience: _configuration.GetValue<string>("JWT:Audience"),
               claims: claims,
               expires: DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:TokenExpiredTimeAtDays", 10)),
               signingCredentials: new SigningCredentials(
                       new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"))),
                               SecurityAlgorithms.HmacSha256));

        var responseModel = new TokenResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),

        };

        return await Task.FromResult(responseModel);
    }
}
