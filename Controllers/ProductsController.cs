using Microsoft.AspNetCore.Mvc;
using Vankov_Pr_6_Var_1.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vankov_Pr_6_Var_1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class ProductsController :ControllerBase
    {
        private WebApiDatabaseContext db;

        public ProductsController(WebApiDatabaseContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult GetAll([FromQuery] string? category, [FromQuery] decimal? minPrice)
        {
            var products = db.Products.ToList();

            if (category != null)
            {
                products = products.Where(p => p.Category == category).ToList();
            }

            if (minPrice != null)
            {
                products = products.Where(p => p.Price >= minPrice).ToList();
            }

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            Product? product = db.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            db.Products.Add(product);
            db.SaveChanges();

            return Created("", product);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Product product)
        {
            Product? oldProduct = db.Products.Find(id);

            if (oldProduct == null)
                return NotFound();

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Quantity = product.Quantity;
            oldProduct.Category = product.Category;
            oldProduct.IsAvailable = product.IsAvailable;

            db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] Product product)
        {
            Product? oldProduct = db.Products.Find(id);

            if (oldProduct == null)
            {
                return NotFound();
            }
            if (product.Name != "string" && product.Name != "")
                oldProduct.Name = product.Name;
            if (product.Price > 0)
                oldProduct.Price = product.Price;
            if (product.Quantity > 0)
                oldProduct.Quantity = product.Quantity;
            if (product.Category != "string" && product.Category != "")
                oldProduct.Category = product.Category;

            oldProduct.IsAvailable = product.IsAvailable;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            Product? product = db.Products.Find(id);

            if (product == null)
                return NotFound();

            db.Products.Remove(product);
            db.SaveChanges();

            return NoContent();
        }
    }
}
