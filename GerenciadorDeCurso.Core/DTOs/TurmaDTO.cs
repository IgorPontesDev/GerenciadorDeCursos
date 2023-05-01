using GerenciadorDeCurso.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorDeCurso.Core.DTOs
{
    public class TurmaDTO
    {
        [Required]
        [StringLength(10)]
        public string? AnoLetivo { get; set; }
        public string? Descricao { get; set; }

        [JsonIgnore]
        public ICollection<Aluno>? Alunos { get; set; }
    }
}
