using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCurso.Domain.Entities
{
    public class TurmaAluno
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        [ForeignKey("Turma")]
        public int TurmaId { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public virtual Turma? Turma { get; set; }
    }
}
