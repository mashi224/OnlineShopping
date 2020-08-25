using AutumnStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Business.Interfaces
{
    public interface IProductManagement
    {
        Task<IEnumerable<ProductDto>> GetProducts(int id);
    }
}
