using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.ModeloProjeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Repositories
{
    public class SituacaoProjetoRepository
    {
        private readonly ProjetoContext _context;

        public SituacaoProjetoRepository(ProjetoContext projetoContext)
        {
            _context = projetoContext;
        }

        //async Task<ActionResult<Projeto>>
        public IEnumerable<SituacaoProjeto> Cosultar()
        {
            return _context.SituacoesProjeto.ToList();
        }

        public SituacaoProjeto Detalhar(int codigo)
        {
            return _context.SituacoesProjeto.Where(x => x.SituacaoProjetoID == codigo).FirstOrDefault();
        }
    }
}
