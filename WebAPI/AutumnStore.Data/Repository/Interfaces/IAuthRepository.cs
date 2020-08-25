using AutumnStore.Entity;
using System;
using System.Threading.Tasks;

namespace AutumnStore.Data.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password, DateTime localDateTime);
        Task<UserForLoginDto> Login(UserForLoginDto userForLoginDto);
        Task<bool> UserExists(string username);
    }
}
