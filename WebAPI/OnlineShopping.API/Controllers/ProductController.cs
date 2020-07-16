using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.API.Data;
using OnlineShopping.API.Dtos;
using OnlineShopping.API.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var products = await _repo.GetProducts(id);
            var ProductDtoToReturn = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(ProductDtoToReturn);
        }
    }
}