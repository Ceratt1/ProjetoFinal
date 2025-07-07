using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [StringLength(11, ErrorMessage = "CPF inválido")]
        public string? Cpf { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Pedido>? Pedidos { get; set; } // Relacionamento
    }
}