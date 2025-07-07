using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // >>> Novo relacionamento com Fornecedor

        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }  // Chave estrangeira

        public Fornecedor? Fornecedor { get; set; }  // Propriedade de navegação
    }
}
