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
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITurmaService _turmaService;

        public TurmasController(ITurmaService turmaService, AppDbContext context)
        {
            _turmaService = turmaService;
            _context = context;
        }

        // GET: api/Turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _turmaService.GetTurmas();
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            try
            {
                return await _turmaService.GetTurma(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }

        // PUT: api/Turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Turmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(TurmaDTO turmaDTO)
        {
            try
            {
                var turma = await _turmaService.PostTurma(turmaDTO);
                return CreatedAtAction("GetTurma", new { id = turma.Value.TurmaId }, turma);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            try
            {
                await _turmaService.DeletaTurma(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turmas?.Any(e => e.TurmaId == id)).GetValueOrDefault();
        }
    }
}
