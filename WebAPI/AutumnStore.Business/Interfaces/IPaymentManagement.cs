using AutumnStore.Entity;
using System.Threading.Tasks;

namespace AutumnStore.Business.Interfaces
{
    public interface IPaymentManagement
    {
        Task<UserForRegisterDto> GetBillingUser(int userId);
    }
}
