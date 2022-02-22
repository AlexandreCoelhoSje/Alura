using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Repositories
{
    public class UsuarioRepository
    {
        private readonly ProjetoContext _context;

        public UsuarioRepository(ProjetoContext projetoContext)
        {
            _context = projetoContext;
        }

        public Usuario Autenticar(string email, string senha)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}
