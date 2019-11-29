using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    // Com essas anotações temos validações no modelo
    [Table("Categoria")]
    public class Category
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caractered")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caractered")]
        [DataType("nvarchar")]
        public string Title { get; set; }
    }
}