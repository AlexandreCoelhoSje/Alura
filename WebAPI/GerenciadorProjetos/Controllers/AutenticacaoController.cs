using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models.Identidade;
using GerenciadorProjetos.Repositories;
using GerenciadorProjetos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ProjetoContext _context;
        private UsuarioRepository _modeloRepository;

        public AutenticacaoController(IConfiguration configuration, ProjetoContext projetoContext)
        {
            _configuration = configuration;
            _context = projetoContext;
            _modeloRepository = new UsuarioRepository(_context);
        }

        [HttpPost]
        public ActionResult Autenticar([FromBody] Usuario model)
        {
            //Recupera o usuário
            var usuario = _modeloRepository.Autenticar(model.Nome, model.Senha);

            //Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            //Gera o Token
            var token = TokenService.GenerateToken(_configuration, usuario);

            //Oculta a senha
            usuario.Senha = "";

            //Retorna os dados
            return Ok(new
            {
                user = usuario,
                token = token
            });
        }
    }
}
