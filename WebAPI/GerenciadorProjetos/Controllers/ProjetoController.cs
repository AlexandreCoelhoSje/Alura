using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.Planejamento;
using GerenciadorProjetos.Repositories;
using AutoMapper;
using GerenciadorProjetos.Dto.Planejamento;

namespace GerenciadorProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoContext _context;
        private readonly IMapper _mapper;
        private SituacaoProjetoRepository _situacaoProjetoRepository;

        public ProjetoController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _situacaoProjetoRepository = new SituacaoProjetoRepository(context);
        }

        // GET: api/Projeto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoDTO>>> GetProjetos()
        {
            var projetos = await _context.Projetos
                .Include(a => a.SituacaoProjeto)
                .Include(b => b.Atividades)
                .ToListAsync();

            var projetosDTO = _mapper.Map<List<ProjetoDTO>>(projetos);

            return projetosDTO;
        }

        // GET: api/Projeto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetoDTO>> GetProjeto(int id)
        {
            var projeto = await _context.Projetos
                .Include(proj => proj.SituacaoProjeto)
                .FirstOrDefaultAsync(proj => proj.ProjetoID == id);

            if (projeto == null)
            {
                return NotFound();
            }

            var projetoDTO = _mapper.Map<ProjetoDTO>(projeto);

            return projetoDTO;
        }

        // PUT: api/Projeto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, ProjetoDTO projetoDto)
        {
            if (id != projetoDto.ProjetoID)
            {
                return BadRequest();
            }

            var situacaoProjeto = _situacaoProjetoRepository.Detalhar(projetoDto.SituacaoProjetoID);

            if (situacaoProjeto == null)
            {
                return BadRequest();
            }

            var projeto = await _context.Projetos
               .Include(proj => proj.SituacaoProjeto)
               .FirstOrDefaultAsync(proj => proj.ProjetoID == id);

            if (projeto == null)
            {
                return NotFound();
            }

            _mapper.Map(projetoDto, projeto);

            _context.Entry(projeto).State = EntityState.Modified;
            _context.Projetos.Update(projeto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
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

        // POST: api/Projeto
        [HttpPost]
        public async Task<ActionResult<ProjetoDTO>> PostProjeto(ProjetoDTO projetoDto)
        {
            var situacaoProjeto = _situacaoProjetoRepository.Detalhar(projetoDto.SituacaoProjetoID);

            if (situacaoProjeto == null)
            {
                return BadRequest();
            }

            //ProjetoDTO para Projeto
            var projeto = _mapper.Map<Projeto>(projetoDto);

            //Atualiza Campos Auxiliares
            projeto.SituacaoProjeto = situacaoProjeto;

            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjeto", new { id = projetoDto.ProjetoID }, projetoDto);
        }

        // DELETE: api/Projeto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projetos.Any(e => e.ProjetoID == id);
        }
    }
}
