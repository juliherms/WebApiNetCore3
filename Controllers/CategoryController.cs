using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
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
    public async Task<ActionResult<Category>> Post(
        [FromBody] Category c,
        [FromServices] DataContext context)
    {
        //faz a validacao da categoria
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try{

            context.Categories.Add(c);
            await context.SaveChangesAsync();
            return Ok(c);

        } catch 
        {
            return BadRequest(new { message = "Não foi possível criar a categoria" });
        }
        
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put(
        int id,
        [FromBody] Category c,
        [FromServices] DataContext context)
    {
        //Verifica se o ID informado é o mesmo do Body
        if(id != c.Id)
            return NotFound(new { message = "Categoria não encontrada"});

        //Verifica se o Body é válido
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        try{
            //faz a atualizacao otimizada - ele verifica propriedade por propriedade
            context.Entry<Category>(c).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(c);
            
        } catch(DbUpdateConcurrencyException) {
            return BadRequest(new { message = "Este registro já foi atualizado por outro processo"});
        } catch(Exception) {
            return BadRequest(new { message = "Não foi possível atualizar a categoria"});
        }
    }

    [HttpDelete]
    [Route("")]
    public async Task<ActionResult<Category>> Delete()
    {
        return Ok();
    }


}