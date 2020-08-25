using AutumnStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts(int id);
    }
}
