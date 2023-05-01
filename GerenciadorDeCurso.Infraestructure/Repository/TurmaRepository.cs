using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using GerenciadorDeCurso.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.Infraestructure.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly AppDbContext _contexto;

        public TurmaRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public Turma BuscaTurmaPorId(int turmaId)
        {
            return _contexto.Turmas.Find(turmaId);
        }
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _contexto.Turmas.ToListAsync();
        }
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {            
            return await _contexto.Turmas.FindAsync(id); ;
        }
        public async Task PutTurma(int id, Turma turma)
        {
            var turmaExistente = BuscaTurmaPorId(id);
            if (turmaExistente == null)
                throw new Exception("Turma não encontrada");

            _contexto.Entry(turmaExistente).CurrentValues.SetValues(turma);

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public async Task PostTurma(Turma turma)
        {
            _contexto.Turmas?.Add(turma);
            await _contexto.SaveChangesAsync();
        }
        public async Task DeletaTurma(Turma turma)
        {
            _contexto.Turmas?.Remove(turma);
            await _contexto.SaveChangesAsync();
        }
        public Turma buscaTurmaExistente(TurmaDTO turma)
        {
            var turmaExiste = _contexto.Turmas.FirstOrDefault(a => a.Descricao == turma.Descricao && a.AnoLetivo == turma.AnoLetivo);
            return turmaExiste;
        }
    }
}
