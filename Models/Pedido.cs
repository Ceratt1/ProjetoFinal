using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; } // Relacionamento

        public DateTime DataPedido { get; set; } = DateTime.Now;
        
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Required]
        public string Status { get; set; } = "Em processamento";
    }
}