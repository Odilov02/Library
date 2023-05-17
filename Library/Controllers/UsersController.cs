using Application.Interfase;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] Users user)
        {
         bool result= await _userService.AddAsync(user);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserCredential userCredential)
        {
            return Ok();
        }
    }
}
