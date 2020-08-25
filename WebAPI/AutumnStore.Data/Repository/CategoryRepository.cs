using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutumnStore.Data.Repository;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using AutoMapper;

namespace AutumnStore.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync(); 
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}
