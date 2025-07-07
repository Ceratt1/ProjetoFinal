using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O comentário não pode estar vazio")]
        [StringLength(500, MinimumLength = 5)]
        public string Texto { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataComentario { get; set; } = DateTime.Now;

        // Relacionamentos
        public int BlogPostId { get; set; }
        public BlogPost? BlogPost { get; set; }

        [StringLength(100)]
        public string? Autor { get; set; } = "Anônimo";
    }
}