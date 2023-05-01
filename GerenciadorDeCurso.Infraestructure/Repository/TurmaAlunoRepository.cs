using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using GerenciadorDeCurso.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.Infraestructure.Repository
{
    public class TurmaAlunoRepository : ITurmaAlunoRepository
    {
        private readonly AppDbContext _context;

        public TurmaAlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAlunosNaTurmaAsync(int turmaId)
        {
            return await _context.TurmaAluno.CountAsync(a => a.TurmaId == turmaId);
        }
        public async Task InsereAlunoNaTurma(TurmaAluno turmaAluno)
        {
            _context.TurmaAluno.Add(turmaAluno);
            await _context.SaveChangesAsync();
        }
        public int ContaAlunosTurma(int turmaId)
        {
            int qtdAlunos = _context.TurmaAluno.Where(a => a.TurmaId == turmaId).Count();
            return qtdAlunos;
        }
        public TurmaAluno BuscaAlunoNaTurma(int AlunoId, int TurmaId)
        {
            return _context.TurmaAluno.FirstOrDefault(a => a.AlunoId == AlunoId && a.TurmaId == TurmaId); ;
        }
        public TurmaAluno BuscaMatriculaAlunoEmAlgumaTurma(int AlunoId)
        {
            return _context.TurmaAluno.FirstOrDefault(a => a.AlunoId == AlunoId);
        }
        public bool BuscaSeTurmaTemAlunos(int turmaId)
        {
            var turmaExiste = _context.TurmaAluno.FirstOrDefault(a=>a.TurmaId == turmaId);
            if(turmaExiste !=null)
                return true;
            else return false;
        }
    }
}
