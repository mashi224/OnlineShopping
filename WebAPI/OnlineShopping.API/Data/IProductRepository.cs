using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.API.Dtos;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Data
{
    public interface IProductRepository
    {
         Task<IEnumerable<Products>> GetProducts(int categoryId);
    }
}