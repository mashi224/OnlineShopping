using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutumnStore.Data.Repository;
using AutumnStore.Data.Model;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using AutoMapper;

namespace AutumnStore.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserForLoginDto> Login(UserForLoginDto userForLoginDto)
        {
            var username = userForLoginDto.UserName.ToLower();
            var password = userForLoginDto.Password;

            User userFromRepo = await _context.User.FirstOrDefaultAsync(x => x.UserName == username);

            if (userFromRepo == null)
                return null;

            if (!VerifyPasswordHash(password, userFromRepo.PasswordHash, userFromRepo.PasswordSalt))
                return null;

            return _mapper.Map<UserForLoginDto>(userFromRepo);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

        public async Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password, DateTime localDateTime)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User user = _mapper.Map<User>(userForRegisterDto);
            // User user = _mapper.Map<UserForRegisterDto, User>(userForRegisterDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserRegisteredDate = localDateTime;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            // return _mapper.Map<UserForRegisterDto>(user);
            return userForRegisterDto;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.User.AnyAsync(x => x.UserName == username))
                return true;

            return false;

        }
    }
}
