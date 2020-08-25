using AutumnStore.Data.Model;
using AutumnStore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutumnStore.Business.Interfaces
{
    public interface IAuthManagement
    {
        Task<UserForLoginDto> Login(UserForLoginDto userForLoginDto);
        Task<bool> Register(UserForRegisterDto userForRegisterDto);
        Task<bool> UserExists(string username);
    }
}
