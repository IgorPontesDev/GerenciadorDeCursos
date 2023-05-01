using GerenciadorDeCurso.Application.Services;
using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Domain.Entities;
using GerenciadorDeCurso.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCurso.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {

            return await _alunoService.GetAlunos();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                return _alunoService.GetAluno(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
                     
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            try
            {
                await _alunoService.PutAluno(id, aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(AlunoDTO alunoDTO)
        {
            try
            {
                var aluno = await _alunoService.PostAluno(alunoDTO);
                return CreatedAtAction(nameof(GetAluno), new { id = aluno.Value.AlunoId }, aluno.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                await _alunoService.DeleteAluno(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }
    }
}
