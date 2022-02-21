using GerenciadorProjetos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Repositories
{
    public class ProjetoRepository
    {
        private readonly ProjetoContext _context;

        public ProjetoRepository(ProjetoContext projetoContext)
        {
            _context = projetoContext;
        }
    }
}
