using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APP.Core.Helpers;

public static class AuthHelper
{
    
    public static string HashUserPassword(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public static bool Verify(string password, string passwordHash) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);

    public static Guid GetCurrentUserId(HttpContext httpContext)
    {
        try
        {
            var userClaim = httpContext.User.Claims.FirstOrDefault(x => x.Type == "userId");
            return Guid.Parse(userClaim.Value);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

