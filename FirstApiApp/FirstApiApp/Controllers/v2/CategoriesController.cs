using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApiApp.Data;
using FirstApiApp.Models;

namespace FirstApiApp.Controllers.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly FirstApiAppContext _context;


        public CategoriesController(FirstApiAppContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            List<Category> categories = new()
    {
        new Category {   Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
        new Category {   Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
        new Category {   Name = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Category {   Name = "Dairy Products", Description = "Cheeses" },
        new Category {   Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category {   Name = "Meat/Poultry", Description = "Prepared meats" },
        new Category {   Name = "Produce", Description = "Dried fruit and bean curd" },
        new Category {   Name = "Seafood", Description = "Seaweed and fish" }
    };
            _context.Categories.AddRange(categories);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
