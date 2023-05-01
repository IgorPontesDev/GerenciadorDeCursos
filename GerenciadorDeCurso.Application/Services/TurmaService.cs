using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using GerenciadorDeCurso.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly ITurmaAlunoRepository _turmaAlunoRepository;
        public TurmaService(ITurmaRepository turmaRepository, ITurmaAlunoRepository turmaAlunoRepository)
        {
            _turmaRepository = turmaRepository;
            _turmaAlunoRepository = turmaAlunoRepository;
        }
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            var listTurma = await _turmaRepository.GetTurmas();
            if (listTurma == null)
                throw new Exception("Lista de turmas está vazia");
            return listTurma;
        }
        public async Task<ActionResult<Turma>> GetTurma(int id) 
        {
            var turma= await _turmaRepository.GetTurma(id);
            if (turma.Value == null)
                throw new Exception("Turma inexistente");
            return turma;
        }
        public async Task PutTurma(int id, Turma turma)
        {
            if (id != turma.TurmaId)
                throw new Exception("Os id's são diferentes!");

            if (_turmaRepository.BuscaTurmaPorId(id) == null)
                throw new Exception("Turma Inexistente");

            await _turmaRepository.PutTurma(id, turma);
        }
        public async Task<ActionResult<Turma>> PostTurma(TurmaDTO turma)
        {
            var criandoTurma = new Turma
            {
                AnoLetivo = turma.AnoLetivo,
                Descricao = turma.Descricao
            };

            var buscaTurma = _turmaRepository.buscaTurmaExistente(turma);
            if (buscaTurma != null)
                throw new Exception("Turma já existe!");

            await _turmaRepository.PostTurma(criandoTurma);

            return criandoTurma;
        }
        public async Task DeletaTurma(int id)
        {
            var turma = _turmaRepository.BuscaTurmaPorId(id);
            if (turma == null)            
                throw new Exception("Turma não existe!");
            if (_turmaAlunoRepository.BuscaSeTurmaTemAlunos(id))            
                throw new Exception("Não é possível excluir uma turma que tem alunos.");           


            await _turmaRepository.DeletaTurma(turma);            
        }
    }
}
