using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutumnStore.Business.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutumnStore.Controller
{
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManagement _categoryManagement;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryManagement categoryManagement, ILogger<CategoryController> logger)
        {
            _categoryManagement = categoryManagement;
            _logger = logger;
        }

        // GET api/category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryManagement.GetCategories();
            _logger.LogInformation("Get categories completed.");
            
            return Ok(categories);
        }
    }
}
