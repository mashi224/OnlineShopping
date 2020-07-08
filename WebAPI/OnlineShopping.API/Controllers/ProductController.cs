using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.API.Data;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace OnlineShopping.API.Controllers
{
    public class ProductController
    {
        // http:localhost:5000/api/products
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly DataContext _context;
            public ProductsController(DataContext context)
            {
                _context = context;
            }

            // GET api/products
            [HttpGet]
            public IActionResult GetProducts()
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }

            // GET api/products/5
            [HttpGet("{id}")]
            public IActionResult GetProducts(int id)
            {
                var products = _context.Products.FirstOrDefault(x => x.Id == id);
                return Ok(products);
            }

            // // POST api/values
            // [HttpPost]
            // public void Post([FromBody] string value)
            // {
            // }

            // // PUT api/products/5
            // [HttpPut("{id}")]
            // public void Put(int id, [FromBody] string value)
            // {
            // }

            // // DELETE api/products/5
            // [HttpDelete("{id}")]
            // public void Delete(int id)
            // {
            // }
        }
    }
}