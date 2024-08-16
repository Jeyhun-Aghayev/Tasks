using Cache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Cache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static List<Category> categories = new()
        {
                new Category { CategoryID = 1, CategoryName = "Beverages",      Description = "Soft drinks, coffees, teas, beers, and ales"},
                new Category { CategoryID = 2, CategoryName = "Condiments",     Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
                new Category { CategoryID = 3, CategoryName = "Confections",    Description = "Desserts, candies, and sweet breads"},
                new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses"},
                new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal"},
                new Category { CategoryID = 6, CategoryName = "Meat/Poultry",   Description = "Prepared meats"},
                new Category { CategoryID = 7, CategoryName = "Produce",        Description = "Dried fruit and bean curd"},
                new Category { CategoryID = 8, CategoryName = "Seafood",        Description = "Seaweed and fish"}
           };


        private const string CACHE_CATEGORY_KEY = "_Category";
        private readonly IMemoryCache _memoryCache;

        public CategoriesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if(!_memoryCache.TryGetValue(CACHE_CATEGORY_KEY,out List<Category> _categories))
            {
                var cacheOption = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                };
                _memoryCache.Set(CACHE_CATEGORY_KEY, cacheOption);
            }
            var ct = _memoryCache.Get(CACHE_CATEGORY_KEY) as List<Category>;
            return Ok(ct);
        }


        [HttpPost]
        public IActionResult Post(Category category)
        {
            int cId = categories.Select(c => c.CategoryID).Max() + 1;
            category.CategoryID = cId;
            categories.Add(category);

            return Ok(category);
        }
    }
}
