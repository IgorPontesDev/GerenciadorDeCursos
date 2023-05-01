using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeCurso.Core.DTOs
{
    public class AlunoDTO
    {
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(12)]
        public string? CPF { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        public int TurmaId { get; set; }
    }
}
