using AutumnStore.Business.Interfaces;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AutumnStore.Data.UnitOfWork;

namespace AutumnStore.Business
{
    public class AuthManagement: IAuthManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public AuthManagement(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<UserForLoginDto> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _unitOfWork.AuthRepository.Login(userForLoginDto);

            if (userFromRepo == null)
                return null;
                //return Unauthorized();  

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            string serializetoken = tokenHandler.WriteToken(token);

            return new UserForLoginDto
            {
                Token = serializetoken
            };

            //return Ok(new
            //{
            //    token = tokenHandler.WriteToken(token)
            //});
        }

        public async Task<bool> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if (await _unitOfWork.AuthRepository.UserExists(userForRegisterDto.UserName))
                return true;

            DateTime localDateTime = DateTime.Now;
            await _unitOfWork.AuthRepository.Register(userForRegisterDto, userForRegisterDto.Password, localDateTime);
            
            return false;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _unitOfWork.AuthRepository.UserExists(username);
        }
    }
}
