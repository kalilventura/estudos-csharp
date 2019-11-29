using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caractered")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caractered")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter até 1024 caractered")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Inválida")]
        public int CategoryId { get; set; }

        // Propriedade de referencia
        public Category Category { get; set; }

        /*
        Obs: Se quisermos somente a referencia da Categoria, ou seja, somente saber a qual ela pertence podemos deixar
        somente o CategoryId.

        Se quisermos saber mais detalhes da categoria, precisamos deixar a propriedade de referencia
        */
    }
}