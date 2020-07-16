using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return categories;
        }
    }
}
