using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeCurso.Domain.Entities
{
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }
        [Required]
        [StringLength(10)]
        public string? AnoLetivo { get; set; }
        public string? Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Aluno>? Alunos { get; set; }
    }
}
