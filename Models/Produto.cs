using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço inválido")]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } // Relacionamento
    }
}