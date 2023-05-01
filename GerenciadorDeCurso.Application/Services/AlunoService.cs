using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly ITurmaAlunoRepository _turmaAlunoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public AlunoService(ITurmaAlunoRepository turmaAlunoRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _turmaAlunoRepository = turmaAlunoRepository;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
        }
        public async Task<ActionResult<Aluno>> PostAluno(AlunoDTO alunoDTO)
        {
            var aluno = new Aluno
            {
                Nome = alunoDTO.Nome,
                CPF = alunoDTO.CPF,
                Email = alunoDTO.Email
            };

            var buscaTurmaExistente = _turmaRepository.BuscaTurmaPorId(alunoDTO.TurmaId);
            if (buscaTurmaExistente == null)
                throw new Exception("Turma não encontrada");

            var contaAlunosTurma = _turmaAlunoRepository.ContaAlunosTurma(alunoDTO.TurmaId);
            if (contaAlunosTurma >= 5)
                throw new Exception("A turma está lotada!");

            var alunoExistente = _alunoRepository.BuscarPorCpf(alunoDTO.CPF);
            if (alunoExistente != null)
            {
                var buscaAlunoNaTurma = _turmaAlunoRepository.BuscaAlunoNaTurma(alunoExistente.AlunoId, alunoDTO.TurmaId);
                if (buscaAlunoNaTurma != null)
                    throw new Exception("Esse aluno já está cadastrado nessa turma!");
            }
            else
            {
                await _alunoRepository.PostAluno(aluno);
            }

            //Após o aluno criado preciso buscar novamente para saber o ID que ele recebeu e inserir na turmaAluno
            var buscaIdDoAluno = _alunoRepository.BuscarPorCpf(alunoDTO.CPF);
            var turmaAluno = new TurmaAluno
            {
                AlunoId = buscaIdDoAluno.AlunoId,
                TurmaId = alunoDTO.TurmaId
            };
            await _turmaAlunoRepository.InsereAlunoNaTurma(turmaAluno);
            return aluno;
        }
        public async Task DeleteAluno(int id)
        {
            if (_alunoRepository.BuscarPorId(id) == null)
                throw new Exception("Aluno não encontrado");

            if (_turmaAlunoRepository.BuscaMatriculaAlunoEmAlgumaTurma(id) != null)
                throw new Exception("Aluno não pode ser excluído pois está matriculado em uma turma");

            _alunoRepository.DeletaAluno(_alunoRepository.BuscarPorId(id));
        }
        public async Task PutAluno(int id, Aluno aluno)
        {            
            if(id != aluno.AlunoId)
                throw new Exception("Os id's são diferentes!");
            if (_alunoRepository.BuscarPorId(id) == null)
                throw new Exception("Aluno Inexistente");

            _alunoRepository.PutAluno(id, aluno);

        }
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _alunoRepository.GetAlunos();
        }
        public Aluno GetAluno(int id)
        {
            var alunoExiste =  _alunoRepository.GetAluno(id);
            if(alunoExiste==null)
                throw new Exception("Aluno Inexistente");

            return alunoExiste;
        }
    }
}
