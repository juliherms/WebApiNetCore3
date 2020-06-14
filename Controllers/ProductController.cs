using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers 
{
    //controller responsavel por prover os servicos de produtos
    [Route("products")]
    public class ProductController : ControllerBase {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            //lista os produtos incluindo a categoria (o include representa um join)
            var products = await context.Products.Include( x => x.Category).AsNoTracking().ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id){

            var product = await context
                .Products
                .Include(x => x.Category )
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id){

            var products = await context
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where( x => x.CategoryId == id) //retorna todos os produtos de uma categoria especifica
                .ToListAsync();

            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product p
        )
        {
            if (ModelState.IsValid){

                context.Products.Add(p);
                await context.SaveChangesAsync();
                return Ok(p);
            }
            else {
                return BadRequest(ModelState);
            }
        }
    }
}


