using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using GerenciadorDeCurso.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.Infraestructure.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task PostAluno(Aluno aluno)
        {
            _context.Alunos?.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public Aluno BuscarPorCpf(string cpf)
        {
            var alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.CPF == cpf);
            return alunoEncontrado;
        }
        public Aluno BuscarPorId(int id)
        {
            return _context.Alunos.Find(id);
        }
        public async Task DeletaAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task PutAluno(int id, Aluno aluno)
        {
            var alunoExistente = BuscarPorId(id);
            if (alunoExistente == null)            
                throw new Exception("Aluno não encontrado");            

            _context.Entry(alunoExistente).CurrentValues.SetValues(aluno);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }
        public Aluno GetAluno(int id)
        {
            return BuscarPorId(id);
        }
    }
}
