using CatalogoAPI.Content;
using CatalogoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //Seria equivalente ao repository
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Product>> Findall()
        {
            var products = _context.Products.ToList();
            if (products is null)
            {
                return NotFound("Product not found!!");
            }
            return products;


        }


        [HttpGet("{id:int}")]
        public ActionResult<Product> FindById(int id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == id);
            if (products is null)
            {
                return NotFound("Prouct is not found!!");
            }
            return products;
        }



        [HttpPost]
        public ActionResult Post(Product product)
        {
            if(product is null)
            {
                return BadRequest("Not null!!");
            }


            _context.Products.Add(product);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetProduct: ", new {id = product.Id}, product);


        }
    }

}
