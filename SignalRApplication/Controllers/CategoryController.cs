using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApplication.Repositories;

namespace SignalRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var types = _categoryRepository.GetAll();
            return Ok(types);
        }
    }
}
