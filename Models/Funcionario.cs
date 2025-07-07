using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cargo obrigatório")]
        public string Cargo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue, ErrorMessage = "Salário inválido")]
        public decimal Salario { get; set; }
    }
}