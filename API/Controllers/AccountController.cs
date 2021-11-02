using System.Linq;
using JustTradeIt.Software.API.Models.InputModels;
using JustTradeIt.Software.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustTradeIt.Software.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, ITokenService tokenService, IUserService userService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _userService = userService;
        }

        // TODO: Setup routes
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser([FromBody] RegisterInputModel register)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(412, register);
            }
            
            return Created("register", _accountService.CreateUser(register));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginInputModel login)
             {
                var user = _accountService.AuthenticateUser(login);
                if (user == null)
                {
                    return Unauthorized();
                }

                var token = _tokenService.GenerateJwtToken(user);
                return Ok(token);
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "tokenId")?.Value, out var tokenId);
            _accountService.Logout(tokenId);
            return NoContent();
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult GetProfileInformation()
        {
            var claims = User.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
            return Ok(claims);
        }

        //[HttpPut]
        //[Route("profile/{id}")]
        //public IActionResult UpdateProfile(int id, [FromBody] ProfileInputModel profile)
        //{
           // return Ok();
        //}
        


}
}
