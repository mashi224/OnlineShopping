using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AutumnStore.Business.Interfaces;

namespace AutumnStore.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase
    {
        private readonly IProductManagement _productManagement;

        public ProductController(IProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        // GET api/product/5
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var products = await _productManagement.GetProducts(categoryId);
            return Ok(products);
        }
    }
}
