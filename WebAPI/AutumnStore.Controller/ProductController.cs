using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AutumnStore.Business.Interfaces;

namespace AutumnStore.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _productManagement;
        private readonly IMapper _mapper;

        public ProductController(IProductManagement productManagement, IMapper mapper)
        {
            _mapper = mapper;
            _productManagement = productManagement;
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var products = await _productManagement.GetProducts(id);
            return Ok(products);
        }
    }
}
