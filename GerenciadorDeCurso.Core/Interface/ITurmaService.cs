using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCurso.Core.Interface
{
    public interface ITurmaService
    {
        Task<ActionResult<IEnumerable<Turma>>> GetTurmas();
        Task<ActionResult<Turma>> GetTurma(int id);
        Task PutTurma(int id, Turma turma);
        Task<ActionResult<Turma>> PostTurma(TurmaDTO turma);
        Task DeletaTurma(int id);
    }
}
