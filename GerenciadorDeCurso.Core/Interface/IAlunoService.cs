using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCurso.Core.Interface
{
    public interface IAlunoService
    {
        Task<ActionResult<Aluno>> PostAluno(AlunoDTO alunoDTO);
        Task DeleteAluno(int id);
        Task PutAluno(int id, Aluno aluno);
        Task<ActionResult<IEnumerable<Aluno>>> GetAlunos();
        Aluno GetAluno(int id);
    }
}
