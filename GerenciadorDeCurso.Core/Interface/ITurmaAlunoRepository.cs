using GerenciadorDeCurso.Domain.Entities;

namespace GerenciadorDeCurso.Core.Interface
{
    public interface ITurmaAlunoRepository
    {
        Task<int> CountAlunosNaTurmaAsync(int turmaId);
        Task InsereAlunoNaTurma(TurmaAluno turmaAluno);
        int ContaAlunosTurma(int turmaId);
        TurmaAluno BuscaAlunoNaTurma(int AlunoId, int TurmaId);
        TurmaAluno BuscaMatriculaAlunoEmAlgumaTurma(int AlunoId);
        bool BuscaSeTurmaTemAlunos(int turmaId);
    }
}
