using AutumnStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutumnStore.Business.Interfaces
{
    public interface ICategoryManagement
    {
        //Task<IEnumerable<CategoryDto>> GetCategories();
        Task<List<CategoryDto>> GetCategories();
    }
}
