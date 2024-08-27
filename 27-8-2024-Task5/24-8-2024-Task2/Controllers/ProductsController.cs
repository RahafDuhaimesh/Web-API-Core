using _24_8_2024_Task2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _24_8_2024_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db) { _db = db; }

        [HttpGet]
        public ActionResult getAllProducts()
        {
            var x = _db.Products.ToList();
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        [HttpGet("api/products/{id:int}")]
        public ActionResult GetProductById( int id)
        {
            if (id <= 0) { return BadRequest(); }
            var x = _db.Products.FirstOrDefault(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        [HttpGet("api/productsCat/{id:int}")]
        public ActionResult GetProductByCatId( int id)
        {
            if (id <= 0) { return BadRequest(); }
            var x = _db.Products.Where(x => x.CategoryId == id).ToList();
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }
        [HttpGet("products/{id:int:max(10)}")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            if (name == null) { return BadRequest(); }
            var x = _db.Products.FirstOrDefault(c => c.ProductName == name);
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }
        [HttpDelete]
        public ActionResult DeleteProduct([FromQuery] int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.Products.FirstOrDefault(f => f.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            _db.Products.Remove(x);
            _db.SaveChanges();

            return Ok();
        }
    }
}
