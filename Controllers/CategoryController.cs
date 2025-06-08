using CatalogoAPI.Content;
using CatalogoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Controllers
{
    [Route("/[category]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context; 
        }

        [HttpGet("/findall")]
        public ActionResult<IEnumerable<Category>> Findall()
        {
            var category = _context.Cartegories.ToList();
            if (category is null)
            {
                return NotFound("Category not found!!");
            }
            return category;


        }

        [HttpGet("{id:int:min:min(1)}")]
        public ActionResult<Category> FindById(int id)
        {
            var category = _context.Cartegories.FirstOrDefault(p => p.Id == id);
            if (category is null)
            {
                return NotFound("Category is not found!!");
            }
            return category;
        }


        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category is null)
            {
                return BadRequest("Not null!!");
            }


            _context.Cartegories.Add(category);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetCategory: ", new { id = category.Id }, category);


        }



        [HttpPut("category/{id:int:min(1)}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("ID not found!");

            }

            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges(true);

            return Ok(category);
        }




        [HttpDelete("delete/{id:int:min(1}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Cartegories.FirstOrDefault(p => p.Id == id);

            if (category is null)
            {
                return NotFound("Category not localizated!");
            }

            _context.Cartegories.Remove(category);
            _context.SaveChanges();

            return Ok(category);

        }

    }
}
