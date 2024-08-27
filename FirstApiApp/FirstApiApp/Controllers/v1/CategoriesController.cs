using FirstApiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiApp.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    static List<Category> categories = new()
    {
        new Category { Id = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
        new Category { Id = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
        new Category { Id = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Category { Id = 4, Name = "Dairy Products", Description = "Cheeses" },
        new Category { Id = 5, Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category { Id = 6, Name = "Meat/Poultry", Description = "Prepared meats" },
        new Category { Id = 7, Name = "Produce", Description = "Dried fruit and bean curd" },
        new Category { Id = 8, Name = "Seafood", Description = "Seaweed and fish" }
    };
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Get All Categories");
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return BadRequest();
        }
        return Ok(category);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        return Ok("Kategory Silindi");
    }
    [HttpPut]
    public IActionResult Put(int id, Category category)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult Post(Category category)
    {
        categories.Add(category);
        return Ok($"Category eklendi: {category.Id} , {category.Name} , {category.Description}");
    }
}
