using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.Planejamento;
using AutoMapper;
using GerenciadorProjetos.Dto.Planejamento;

namespace GerenciadorProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ProjetoContext _context;
        private readonly IMapper _mapper;

        public TarefaController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tarefa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> GetTarefas(string ordenacao, bool? asc, int id, string descricao)
        {
            //Consulta Base
            var tarefas = await _context.Tarefas
                .Where(ent => ent.AtividadeID == id)
                .ToListAsync();

            //Filtro
            if (!string.IsNullOrEmpty(descricao))
                tarefas = tarefas.Where(ent => ent.Descricao.Contains(descricao)).ToList();

            //Ordenacao
            if (!string.IsNullOrEmpty(ordenacao))
            {
                if (asc == true)
                    tarefas = tarefas.OrderBy(ent => ent.Descricao).ToList();
                else
                    tarefas = tarefas.OrderByDescending(ent => ent.Descricao).ToList();
            }

            return _mapper.Map<List<TarefaDTO>>(tarefas);
        }

        // GET: api/Tarefa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return _mapper.Map<TarefaDTO>(tarefa);
        }

        // PUT: api/Tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, TarefaDTO tarefaDto)
        {
            if (id != tarefaDto.TarefaID)
            {
                return BadRequest();
            }
            
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa.AtividadeID != tarefaDto.AtividadeID)
            {
                return BadRequest();
            }

            _mapper.Map(tarefaDto, tarefa);

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
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

        // POST: api/Tarefa
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(TarefaDTO tarefaDto)
        {
            if (!_context.Atividades.Any(ent => ent.AtividadeID == tarefaDto.AtividadeID))
            {
                BadRequest();
            }

            var tarefa = _mapper.Map<Tarefa>(tarefaDto);

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { id = tarefa.TarefaID }, _mapper.Map<TarefaDTO>(tarefa));
        }

        // DELETE: api/Tarefa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.TarefaID == id);
        }
    }
}
