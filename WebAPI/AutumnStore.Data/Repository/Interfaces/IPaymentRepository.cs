using AutumnStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutumnStore.Data.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<UserForRegisterDto> GetBillingUser(int userId);
    }
}
