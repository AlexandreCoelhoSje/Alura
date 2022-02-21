using GerenciadorProjetos.Models.Autorizacao;
using GerenciadorProjetos.Models.Identidade;
using GerenciadorProjetos.Models.ModeloProjeto;
using GerenciadorProjetos.Models.Scrum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjetoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TiposColunasKanban.Any())
            {
                return;   // DB has been seeded
            }

            #region Autorizacao
            var funcoes = new Funcao[]
            {
                new Funcao{Descricao = "Administrador"},
                new Funcao{Descricao = "Colaborador"}
            };
            foreach (Funcao s in funcoes)
            {
                context.Funcoes.Add(s);
            }
            context.SaveChanges();
            #endregion

            #region Identidade
            var usuario = new Usuario()
            {
                Nome = "Alexandre",
                Email = "alexandresilvasje@gmail.com",
                Senha = "123454"
            };            
            context.Usuarios.Add(usuario);            
            context.SaveChanges();
            #endregion

            #region Projetos
            var situacoesProjeto = new SituacaoProjeto[]
            {
                new SituacaoProjeto{Descricao = "Aberto"},
                new SituacaoProjeto{Descricao = "Em Andamento"},
                new SituacaoProjeto{Descricao = "Finalizado"}
            };
            foreach (SituacaoProjeto s in situacoesProjeto)
            {
                context.SituacoesProjeto.Add(s);
            }
            context.SaveChanges();
            #endregion

            #region Scrum
            var tipoColunasKanban = new TipoColunaKanban[]
            {
                new TipoColunaKanban{Descricao = "Backlog"},
                new TipoColunaKanban{Descricao = "A Fazer"},
                new TipoColunaKanban{Descricao = "Fazendo"},
                new TipoColunaKanban{Descricao = "Finalizado"}
            };
            foreach (TipoColunaKanban s in tipoColunasKanban)
            {
                context.TiposColunasKanban.Add(s);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
