using _24_8_2024_Task2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _24_8_2024_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public OrdersController(MyDbContext db) { _db = db; }

        [HttpGet("Orders/ALL")]
        public IActionResult getAllOrders()
        {
            var x = _db.Orders.ToList();
            if (x == null) { return NotFound(); }
            return Ok(x);
        }
        [HttpGet("Orders/ById")]
        public IActionResult GetOrderById([FromQuery] int id)
        {
            if (id <= 0) { return BadRequest(); }
            var x = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (x == null) { return NotFound(); };
            return Ok(x);
        }

        [HttpGet("GetOrderByNames")]
        public IActionResult GetOrderByNames([FromQuery] string name)
        {
            if (name == null)
            {
                return BadRequest("Name cannot be null or empty.");
            }

            var orders = _db.Orders.Where(e => e.User.UserName == name).ToList();
            if (orders == null)
            {
                return NotFound($"No orders found for username: {name}");
            }

            return Ok(orders);
        }

        [HttpDelete("Orders/{id:int}")]
        public IActionResult Delete([FromQuery] int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.Orders.FirstOrDefault(f => f.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(x);
            _db.SaveChanges();

            return Ok();

        }

    }
}
