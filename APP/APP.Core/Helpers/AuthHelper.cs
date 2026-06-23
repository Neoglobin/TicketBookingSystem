using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DB.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APP.Core.Helpers;

public class AuthHelper
{
    
    public static string HashUserPassword(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public static bool Verify(string password, string passwordHash) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
}

