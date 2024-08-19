using _19_8_2024_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _19_8_2024_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ProductsController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var product = _db.Products.ToList();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            return Ok(product);
        }
    }
}
