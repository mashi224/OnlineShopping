using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.API.Data;
using OnlineShopping.API.Dtos;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // GET api/category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.GetCategories();
            var categoryDtoToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtoToReturn);
        }
    }
}
