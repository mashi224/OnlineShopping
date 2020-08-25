using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutumnStore.Data.Repository;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutumnStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(int id)
        {
            var products = await _context.Products.Where(x => x.category.Id == id).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
