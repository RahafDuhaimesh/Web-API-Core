using _24_8_2024_Task2.DTOs;
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
        [HttpGet("getall")]
        public ActionResult getAllProductsByOrder()
        {

            var x = _db.Products.OrderByDescending(x => x.Price).ToList();
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        [HttpGet("api/products/{id:int}")]
        public ActionResult GetProductById(int id)
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
        public ActionResult GetProductByCatId(int id)
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
        [HttpPost]
        public IActionResult CreateProduct([FromForm] ProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (productDTO.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, productDTO.ProductImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productDTO.ProductImage.CopyToAsync(stream);
                }
                var x = new Product
                {
                    CategoryId = productDTO.CategoryId,
                    ProductName = productDTO.ProductName,
                    Description = productDTO.Description,
                    ProductImage = productDTO.ProductImage.FileName,
                    Price = productDTO.Price
                };
                _db.Products.Add(x);
                _db.SaveChanges();
                return Ok();

            }
            return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromForm] ProductRequestDTO productDto)
        {
            
            
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, productDto.ProductImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productDto.ProductImage.CopyToAsync(stream);
                }
            
            var x = _db.Products.Find(id);
            if (x == null)
            {
                return NotFound();
            }

            x.ProductName = productDto.ProductName ?? x.ProductName;
            x.Description = productDto.Description ?? x.Description;
            if (productDto.ProductImage != null)
            {
                x.ProductImage = productDto.ProductImage.FileName;
            }
            x.Price = productDto.Price;

            _db.Products.Update(x);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
