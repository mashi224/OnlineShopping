using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.API.Data;
using OnlineShopping.API.Dtos;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) 
        {
            // Validate request
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if(await _repo.UserExists(userForRegisterDto.UserName)) 
                return BadRequest("User already exists");

            var userToCreate = new User 
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            
            return StatusCode(201);
        }
    }
}