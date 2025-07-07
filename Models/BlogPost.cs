using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Conteudo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        public string? Autor { get; set; } = "Admin";

        // Relacionamento
        public List<Comentario>? Comentarios { get; set; }
    }
}