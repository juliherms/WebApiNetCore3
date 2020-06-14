using Microsoft.AspNetCore.Mvc;

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
    public string Post()
    {
        return "POST";
    }

    [HttpPut]
    [Route("")]
    public string Put()
    {
        return "PUT";
    }

    [HttpDelete]
    [Route("")]
    public string Delete()
    {
        return "DELETE";
    }


}