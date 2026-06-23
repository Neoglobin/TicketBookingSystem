using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APP.Core.Interfaces;
using APP.Core.Options;
using DB.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APP.Core.Services;

public class AuthService(IOptions<JwtOptions> jwtOptions) : IAuthService
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;
    
    public string GenerateJWT(User user)
    {
        Claim[] claims = [
            new("userId", user.Id.ToString())
        ];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}