using Domain.Models;
using System.Security.Claims;

namespace Application.Services;

public interface ITokenService
{
    Task<string> CreateAccesToken(Users user);
    string CreateRefreshAccesToken(Users users);
    bool IsActive(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

}
