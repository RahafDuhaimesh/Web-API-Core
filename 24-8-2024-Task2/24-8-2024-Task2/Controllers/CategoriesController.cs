﻿using _24_8_2024_Task2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _24_8_2024_Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db)
        {
            _db = db;
        }

        [Route("Categories/ALL")]
        [HttpGet]
        public IActionResult getAllCategories()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }

        [Route("Categories/{id:int:min(2)}")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            if (id <= 0) { return BadRequest(); }

            var x = _db.Categories.FirstOrDefault(d => d.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);

        }

        [Route("Categories/{Name}")]
        [HttpGet]
        public IActionResult GetCategoryByName(string Name)
        {
            if (Name == null) { return BadRequest(); }
            var y = _db.Categories.FirstOrDefault(x => x.CategroyName == Name);
            if (y == null)
            {
                return NotFound();
            }
            return Ok(y);
        }

        [Route("Categories/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            if (id <= 0) { return BadRequest(); }

            var y = _db.Products.Where(x => x.CategoryId == id).ToList();
            if (y == null)
            {
                return NotFound();
            }
            _db.Products.RemoveRange(y);
            _db.SaveChanges();


            var x = _db.Categories.FirstOrDefault( j => j.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(x);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
