using Microsoft.AspNetCore.Mvc;
using BackAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly PcShopContext db;

        public CategoriesController(PcShopContext pcShopContext)
        {
            db = pcShopContext;

            if (db.Category.Count() == 0)
            {
                var categories = new Category[]
                {
                    new Category
                    {
                        //category_id = 1,
                        category_name = "Видеокарты"
                    },
                    new Category
                    {
                        //category_id = 2,
                        category_name = "Процессоры"
                    }
                };
                foreach (Category category in categories)
                {
                    db.Category.Add(category);
                }
                db.SaveChanges();
            }

        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }

        [HttpGet("{category_id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int category_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await db.Category.SingleOrDefaultAsync(c => c.category_id == category_id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Category.Add(category);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetCategory", new { category_id = category.category_id }, category);
        }

        [HttpPut("{category_id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int category_id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.Category.Find(category_id);

            if (item == null)
            {
                return NotFound();
            }

            item.category_id = category.category_id;
            item.category_name = category.category_name;

            db.Category.Update(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{category_id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int category_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.Category.Find(category_id);

            if (item == null)
            {
                return NotFound();
            }

            db.Category.Remove(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

    }
}
