using GerenciadorDeCurso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace GerenciadorDeCurso.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Turma>? Turmas { get; set; }
        public DbSet<TurmaAluno>? TurmaAluno { get; set; }

    }
}
