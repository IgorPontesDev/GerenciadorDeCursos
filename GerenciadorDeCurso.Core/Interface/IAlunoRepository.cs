using GerenciadorDeCurso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCurso.Core.Interface
{
    public interface IAlunoRepository
    {
        Aluno BuscarPorCpf(string cpf);
        Task DeletaAluno(Aluno aluno);
        Task PutAluno(int id, Aluno aluno);
        Task PostAluno(Aluno aluno);
        Aluno BuscarPorId(int id);
        Task<ActionResult<IEnumerable<Aluno>>> GetAlunos();
        Aluno GetAluno(int id);
    }

}
