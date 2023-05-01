using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeCurso.Domain.Entities
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(12)]
        public string? CPF { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
    }
}
