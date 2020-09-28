using AutumnStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Business.Interfaces
{
    public interface IPaymentManagement
    {
        Task<UserForRegisterDto> GetBillingUser(int userId);
        Task<IEnumerable<OrderDetailsDto>> CompletePayment(OrderDto orderDto);
    }
}
