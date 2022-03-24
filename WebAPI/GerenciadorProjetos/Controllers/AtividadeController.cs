using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.Planejamento;

namespace GerenciadorProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly ProjetoContext _context;

        public AtividadeController(ProjetoContext context)
        {
            _context = context;
        }

        // GET: api/Atividade
        [HttpGet]
        public async Task<ActionResult<Projeto>> GetAtividades(string ordenacao, bool asc, int id, string descricao)
        {
            //Consulta Base
            var projeto = await _context.Projetos
                .Include(proj => proj.Atividades)
                .Include(proj => proj.SituacaoProjeto)
                .Where(proj => proj.ProjetoID == id)
                .FirstAsync();

            //Filtro
            if (!string.IsNullOrEmpty(descricao))
            {
                projeto.Atividades = projeto.Atividades.Where(atv => atv.Descricao == descricao).ToList();
            }

            //Ordenacao
            if (!string.IsNullOrEmpty(ordenacao))
            { 
                if (asc)
                    projeto.Atividades = projeto.Atividades.OrderBy(atv => atv.Descricao).ToList();
                else
                    projeto.Atividades = projeto.Atividades.OrderByDescending(atv => atv.Descricao).ToList();
            }

            return projeto;
        }

        // GET: api/Atividade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
            var atividade = await _context.Atividades
                .Include(atv => atv.Projeto)
                .Where(atv => atv.AtividadeID == id)
                .FirstAsync();

            if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        // PUT: api/Atividade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (id != atividade.AtividadeID)
            {
                return BadRequest();
            }

            Atividade atividadeBanco = await _context.Atividades.FindAsync(id);

            if (atividadeBanco == null)
                return NotFound();

            //Aletra apenas os campos permitidos
            atividadeBanco.Descricao = atividade.Descricao;
            atividadeBanco.CodigoIdentificador = atividade.CodigoIdentificador;
            atividadeBanco.EsforcoEstimado = atividade.EsforcoEstimado;
            atividadeBanco.EsforcoReal = atividade.EsforcoReal;
            atividadeBanco.NumeroOrdenacao = atividade.NumeroOrdenacao;
            atividadeBanco.Observacao = atividade.Observacao;

            _context.Entry(atividadeBanco).State = EntityState.Modified;

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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividade.AtividadeID }, atividade);
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
