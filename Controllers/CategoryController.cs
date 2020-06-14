using Microsoft.AspNetCore.Mvc;
using Shop.Models;

//Representa o controller de categoria
//https://localhost:5001/categories

[Route("categories")]
public class CategoryController : ControllerBase {

    [HttpGet]
    [Route("")]
    public string Get()
    {
        return "Olá mundo!";
    }

    //exemplo de consulta por id com restrição
    [HttpGet]
    [Route("{id:int}")]
    public string GetById(int id)
    {
        return "GET" + id.ToString();
    }

    [HttpPost]
    [Route("")]
    public Category Post([FromBody] Category c)
    {
        //realiza o parser via ModelBinder do JSON para o Objeto
        return c;
    }

    [HttpPut]
    [Route("{id:int}")]
    public Category Put(int id, [FromBody] Category c)
    {
        if(c.Id == id)
        return c;

        return null;
    }

    [HttpDelete]
    [Route("")]
    public string Delete()
    {
        return "DELETE";
    }


}