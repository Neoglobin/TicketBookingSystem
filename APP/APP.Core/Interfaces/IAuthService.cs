using DB.Entities;

namespace APP.Core.Interfaces;

public interface IAuthService
{
    public string GenerateJWT(User user);
}