using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

//Representa o controller de categoria
//https://localhost:5001/categories
//realiza o parser via ModelBinder do JSON para o Objeto
//desde o C# 6.0 foi incorporado o Async Await(Event loop) Task

[Route("categories")]
public class CategoryController : ControllerBase {

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    //exemplo de consulta por id com restrição
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post([FromBody] Category c)
    {
        return Ok(c);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put(int id, [FromBody] Category c)
    {
        if(c.Id == id)
        return Ok(c);

        return NotFound();
    }

    [HttpDelete]
    [Route("")]
    public async Task<ActionResult<Category>> Delete()
    {
        return Ok();
    }


}