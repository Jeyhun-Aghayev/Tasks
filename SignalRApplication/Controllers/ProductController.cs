using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApplication.Repositories;

namespace SignalRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository; 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var types = _productRepository.GetAll();
            return Ok(types);
        }
    }
   
}
