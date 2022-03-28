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
    public class AtividadeController : ControllerBase
    {
        private readonly ProjetoContext _context;
        private readonly IMapper _mapper;

        public AtividadeController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Atividade
        [HttpGet]
        public async Task<ActionResult<List<AtividadeConsultaDTO>>> GetAtividades(string ordenacao, bool? asc, int id, string descricao)
        {
            //Consulta Base
            var listaAtividades = await _context.Atividades
                .Where(proj => proj.ProjetoID == id)
                .ToListAsync();

            //Filtro
            if (!string.IsNullOrEmpty(descricao))
                listaAtividades = listaAtividades.Where(atv => atv.Descricao.Contains(descricao)).ToList();

            //Ordenacao
            if (!string.IsNullOrEmpty(ordenacao))
            {
                if (asc == true)
                    listaAtividades = listaAtividades.OrderBy(atv => atv.Descricao).ToList();
                else
                    listaAtividades = listaAtividades.OrderByDescending(atv => atv.Descricao).ToList();
            }

            return _mapper.Map<List<AtividadeConsultaDTO>>(listaAtividades);
        }

        // GET: api/Atividade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtividadeDetalheDTO>> GetAtividade(int id)
        {
            var atividade = await _context.Atividades
                .Include(atv => atv.Projeto)
                .Where(atv => atv.AtividadeID == id)
                .FirstAsync();

            if (atividade == null)
            {
                return NotFound();
            }

            return _mapper.Map<AtividadeDetalheDTO>(atividade);
        }

        // PUT: api/Atividade/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, AtividadeDetalheDTO atividadeDto)
        {
            if (id != atividadeDto.AtividadeID)
            {
                return BadRequest();
            }

            Atividade atividade = await _context.Atividades.FindAsync(id);

            if (atividade == null)
            {
                return NotFound();
            }

            if (atividade.ProjetoID != atividadeDto.ProjetoID)
            {
                var projeto = await _context.Projetos.FindAsync(atividadeDto.ProjetoID);

                if (projeto == null)
                    return BadRequest();
            }

            _mapper.Map(atividadeDto, atividade);

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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

        // POST: api/Atividade
        [HttpPost]
        public async Task<ActionResult<AtividadeDetalheDTO>> PostAtividade(AtividadeDetalheDTO atividadeDto)
        {
            var projeto = await _context.Projetos.FindAsync(atividadeDto.ProjetoID);

            if (projeto == null)
                return BadRequest();

            var atividade = _mapper.Map<Atividade>(atividadeDto);

            _context.Atividades.Add(atividade);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividadeDto.AtividadeID }, _mapper.Map<AtividadeDetalheDTO>(atividade));
        }

        // DELETE: api/Atividade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividades.Any(e => e.AtividadeID == id);
        }
    }
}
