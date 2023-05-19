using Application.Extentions;
using Application.Interfase;
using Application.Services;
using Domain.Models;
using Domain.Models.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UsersController(IUserService userService,ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] Users entity)
        {
            try
            {
            Users user = new()
            {
               
                UserName = entity.UserName,
                Password = entity.Password!.StringHash(),
                Email = entity.Email,
            };
         bool result= await _userService.AddAsync(user);
            return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserCredential userCredential)
        {
            Users? user=_userService.GetAll().FirstOrDefault(x=>x.UserName==userCredential.UserName&&
                                                                x.Password==userCredential.Password!.StringHash());
            if (user == null)
            {
                return BadRequest("Not User");
            }
            else {
                Token token = new()
                {
                    AccesToken =await _tokenService.CreateAccesToken(user),
                    RefreshToken = _tokenService.CreateRefreshAccesToken(user)
                };
            return Ok(token);
            }
        }
        [HttpPost]
        [Route("RefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] Token oldToken)
        {
            try
            {
            System.Security.Claims.ClaimsPrincipal? claimsPrincipal = _tokenService.GetPrincipalFromExpiredToken(oldToken!.AccesToken!);  
          int UserId=int.Parse(claimsPrincipal.FindFirstValue(claimType:"id")!);
            Users user =await _userService.GetByIdAsync(UserId);
            bool IsActiveRefresh = _tokenService.IsActive(oldToken.RefreshToken!);
            if (IsActiveRefresh)
            {
                Token newToken = new()
                {
                    AccesToken =await _tokenService.CreateAccesToken(user),
                    RefreshToken = _tokenService.CreateRefreshAccesToken(user)
                };
                return Ok(newToken);
            }
            else
            {
                return BadRequest("Token Not Active");
            }

            }
            catch (Exception)
            {

                return BadRequest("Token Not Active");
            }
        }

    }
}
