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
    public class ProductsController : Controller
    {
        private readonly PcShopContext db;

        public ProductsController(PcShopContext pcShopContext)
        {
            db = pcShopContext;
            if (db.Products.Count() == 0)
            {
                var products = new Products[]
               {
                    new Products
                {
                   // product_id = 1,
                    product_name = "RTX 3090",
                    technical_specifications = "Объем видеопамяти 24 ГБ Тип памяти GDDR6X Разрядность шины памяти 384 бит Максимальная пропускная способность памяти 936 Гбайт/сек",
                    count_of_products = 1,
                    product_price = 356000,
                    discount = 3,
                    category_FK = 1

                },
                new Products
                {
                    //product_id = 2,
                    product_name = "Intel Core i7-9700",
                    technical_specifications = "Ядро Coffee Lake RТехпроцесс 14 нмКоличество ядер 8Максимальное число потоков 8Кэш L1 (инструкции) 256 КБКэш L1 (данные) 256 КБОбъем кэша L2 2 МБОбъем кэша L3 12 МБ",
                    count_of_products = 6,
                    product_price = 23599,
                    discount = 0,
                    category_FK = 2
                }, new Products
                {
                   // product_id = 3,
                    product_name = "ASUS ROG Strix GeForce RTX 3080 Ti OC",
                    technical_specifications = "Объем видеопамяти 12 ГБТип памяти GDDR6XПропускная способность памяти на один контакт 19 Гбит/сРазрядность шины памяти 384 битМаксимальная пропускная способность памяти 912 Гбайт/сек",
                    count_of_products = 10,
                    product_price = 179999,
                    discount = 5,
                    category_FK = 1
                }, new Products
                {
                   // product_id = 4,
                    product_name = "Жесткий диск Seagate 7200 BarraCuda",
                    technical_specifications = "Объем HDD 1ТБ",
                    count_of_products = 46,
                    product_price = 2799,
                    discount = 0,
                    category_FK = 6
                }, new Products
                {
                   // product_id = 5,
                    product_name = "Ноутбук ASUS ROG Zephyrus DUO 15 SE GX551QS-HB099T",
                    technical_specifications = "Видеокарта RTX 3080 для ноутбуков, Процессор AMD Ryzen 9 5900HX, Экран Ultra HD 4K",
                    count_of_products = 3,
                    product_price = 352999,
                    discount = 10,
                    category_FK = 9
                }
               };
                foreach (Products product in products)
                {
                    db.Products.Add(product);
                }
                db.SaveChanges();
            }

            if (db.Category.Count() == 0)
            {
                db.Category.Add(new Category
                {
                   // category_id = 1,
                    category_name = "Видеокарты"
                });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Products> GetAll()
        {
            return db.Products.Include(p => p.Category);
        }

        [HttpGet("{product_id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int product_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await db.Products.Include(p => p.Category.Products).SingleOrDefaultAsync(p => p.product_id == product_id);

            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //products.product_id = db.Products.Last().product_id + 1;
            db.Products.Add(products);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetProducts", new { product_id = products.product_id }, products);
        }

        [HttpPut("{product_id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int product_id, [FromBody] Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.Products.Find(product_id);

            if (item == null)
            {
                return NotFound();
            }

            item.product_id = products.product_id;
            item.product_name = products.product_name;
            item.technical_specifications = products.technical_specifications;
            item.count_of_products = products.count_of_products;
            item.product_price = products.product_price;
            item.discount = products.discount;
            item.category_FK = products.category_FK;

            db.Products.Update(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{product_id}")]
        public async Task<IActionResult> DeleteDeposit([FromRoute] int product_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.Products.Find(product_id);

            if (item == null)
            {
                return NotFound();
            }

            db.Products.Remove(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

    }
}
