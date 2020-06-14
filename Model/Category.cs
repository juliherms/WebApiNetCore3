using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{   
    //classe responsavel por representar uma categoria
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caracteres")]
        [DataType("nvarchar")]
        public string Title { get; set;}

    }
}