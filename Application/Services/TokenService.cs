using Application.Extentions;
using Application.Interfase;
using Domain.Models;
using Domain.Models.Roles;
using Domain.Models.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenService _tokenService;
        private readonly IRoleUserService _roleUserService;
        private readonly IRoleService _roleService;
        private readonly IRolePermissionService _rolePermissionService;
        private readonly IPermissionService _permissionService;

        public TokenService(IConfiguration configuration, IRefreshTokenService tokenService,IRoleUserService roleUserService,IRoleService roleService,IRolePermissionService rolePermissionService,IPermissionService permissionService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _roleUserService = roleUserService;
            _roleService = roleService;
            _rolePermissionService = rolePermissionService;
           _permissionService = permissionService;
        }
        public async Task<string> CreateAccesToken(Users user)
        {
            try
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("username", user!.UserName!));
                claims.Add(new Claim("id", user.Id.ToString()));
                int UserId = user.Id;
                List<RoleUser> RoleUsers = (_roleUserService.GetAll().Where(x => x.UsersId == UserId)).ToList();
                List<RolePermission> rolePermissions=new List<RolePermission>();
                foreach (RoleUser roleUser in RoleUsers)
                {
                  
                    rolePermissions.AddRange(_rolePermissionService.GetAll().Where(x=>x.RoleId==roleUser.RoleId));
                } 
                foreach (var rolePermission in rolePermissions)
                {
                    Permission permission=await _permissionService.GetByIdAsync(rolePermission.Id);
                    claims.Add(new Claim(ClaimTypes.Role, permission.Name));
                }
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:AccesExpires"]!)),
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)),
                            SecurityAlgorithms.HmacSha256)
                    ) ;
                string result = new JwtSecurityTokenHandler().WriteToken(token);
                return result;
            }
            catch (Exception)
            {

                return null!;
            }
        }

        public string CreateRefreshAccesToken(Users users)
        {
            try
            {
                string? tokenString = DateTime.UtcNow.ToString() + users.UserName;
                tokenString = tokenString.StringHash();

                RefreshToken? token = _tokenService.GetAll().FirstOrDefault(x => x.UserName == users.UserName);
                if (token == null)
                {
                    RefreshToken refreshToken = new()
                    {
                        Token = tokenString,
                        ActiveDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:RefreshExpires"]!)),
                        UserName = users.UserName,
                    };
                    _tokenService.AddAsync(refreshToken);
                }
                else
                {
                    token.Token = tokenString;
                    token.ActiveDate = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:RefreshExpires"]!));
                    _tokenService.UpdateAsync(token);
                }
                return tokenString;
            }
            catch (Exception)
            {

                return null!;
            }
        }
        public bool IsActive(string token)
        {

            try
            {
                RefreshToken refreshToken = _tokenService.GetAll().FirstOrDefault(x => x.Token == token)!;
                if (DateTime.UtcNow < refreshToken.ActiveDate)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;

            }

        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var Key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidAudience = _configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!))
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new();

                }
                return principal;

            }
            catch (Exception)
            {

                return new();
            }
        }
    }
}
