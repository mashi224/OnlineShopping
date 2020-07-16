using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Data
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}