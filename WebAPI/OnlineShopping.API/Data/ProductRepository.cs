using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.API.Dtos;
using OnlineShopping.API.Models;
// using OnlineShopping.API.Utilities;

namespace OnlineShopping.API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetProducts(int id)
        {
            var products = await _context.Products.Where(x => x.category.Id == id).ToListAsync();
            // return ModelMapper.ConvertToProductDto(products);
            return products;
        }
    }
}
