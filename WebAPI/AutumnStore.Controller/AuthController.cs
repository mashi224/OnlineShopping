using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutumnStore.Entity;
using AutumnStore.Business.Interfaces;

namespace AutumnStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManagement _authManagement;
        public AuthController(IAuthManagement authManagement)
        {
            _authManagement = authManagement;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            if (await _authManagement.Register(userForRegisterDto))
                return BadRequest("User already exists");
            else
                return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authManagement.Login(userForLoginDto);

            if (userFromRepo == null)
                return Unauthorized();

            return Ok(new
            {
                token = userFromRepo.Token
            });
        }
    }
}
