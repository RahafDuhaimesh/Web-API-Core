using _24_8_2024_Task2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _24_8_2024_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UsersController(MyDbContext db) { _db = db; }

        [HttpGet]
        [Route("Users/All")]
        public IActionResult getAllUsers()
        {
            var x = _db.Users.ToList();
            if (x == null) { return NotFound(); }
            return Ok(x);
        }

        [Route("Users/{id:int}")]
        [HttpGet]

        public IActionResult GetUserById(int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.Users.FirstOrDefault(d => d.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        [Route("Users/{Name}")]
        [HttpGet]
        public IActionResult GetUsersByName(string Name)
        {
            if (Name == null) { return BadRequest(); }
            var y = _db.Users.FirstOrDefault(x => x.UserName == Name);
            if (y == null)
            {
                return NotFound();
            }
            return Ok(y);
        }

        [Route("Users/{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0) { return BadRequest(); }
            var x = _db.Users.FirstOrDefault(f => f.Id == id);
            if (x == null) { return NotFound(); }
            _db.Users.Remove(x);
            _db.SaveChanges();
            return Ok();
        }

    }
}