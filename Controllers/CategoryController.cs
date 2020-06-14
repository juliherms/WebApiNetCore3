using Microsoft.AspNetCore.Mvc;

//Representa o controller de categoria
//https://localhost:5001/categories

[Route("categories")]
public class CategoryController : ControllerBase {

    [Route("")]
    public string MeuMetodo()
    {
        return "Olá mundo!";
    }
}