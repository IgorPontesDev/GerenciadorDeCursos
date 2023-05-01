using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCurso.Core.Interface
{
    public interface ITurmaRepository
    {
        Turma BuscaTurmaPorId(int turmaId);        
        Task<ActionResult<Turma>> GetTurma(int id);
        Task<ActionResult<IEnumerable<Turma>>> GetTurmas();
        Task PutTurma(int id, Turma turma);
        Task PostTurma(Turma turma);
        Task DeletaTurma(Turma turma);
        Turma buscaTurmaExistente(TurmaDTO turma);
    }
}
