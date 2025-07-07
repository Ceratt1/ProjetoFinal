using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Razão Social obrigatória")]
        public string RazaoSocial { get; set; }

        [StringLength(14, ErrorMessage = "CNPJ inválido")]
        public string? Cnpj { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Telefone inválido")]
        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}