using AutumnStore.Business.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using System.Threading.Tasks;

namespace AutumnStore.Business
{
    public class PaymentManagement : IPaymentManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserForRegisterDto> GetBillingUser(int userId)
        {
            return await _unitOfWork.PaymentRepository.GetBillingUser(userId);
        }
    }
}
