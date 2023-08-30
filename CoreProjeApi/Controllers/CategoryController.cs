using CoreProjeApi.DAL.ApiContext;
using CoreProjeApi.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
           using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           using var c = new Context();
            var value = c.Categories.Find(id);
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public IActionResult Add(Category p)
        {
            using var context = new Context();
            context.Add(p);
            context.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using var context = new Context();
            var value = context.Categories.Find(id);
            if (value != null)
            {
                context.Remove(value);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut] public IActionResult Update(Category p)
        {
            using var context = new Context();
            var value = context.Find<Category>(p.CategoryID);
            if (value != null)
            {
                value.CategoryName = p.CategoryName;
                context.Update(value);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
