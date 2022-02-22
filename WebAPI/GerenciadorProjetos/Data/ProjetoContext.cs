using GerenciadorProjetos.Models.Autorizacao;
using GerenciadorProjetos.Models.Identidade;
using GerenciadorProjetos.Models.ModeloProjeto;
using GerenciadorProjetos.Models.Scrum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Data
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options)
        {

        }

        //Autorizacao
        public DbSet<Funcao> Funcoes { get; set; }

        //Identidade
        public DbSet<Usuario> Usuarios { get; set; }

        //Projeto
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<FuncaoProjeto> FuncoesProjeto { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<SituacaoProjeto> SituacoesProjeto { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        //Scrum
        public DbSet<ColunaKanban> ColunasKanban { get; set; }
        public DbSet<QuadroKanban> QuadrosKanban { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<TipoColunaKanban> TiposColunasKanban { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Funcao>().ToTable("Funcao");

            //modelBuilder.Entity<Usuario>().ToTable("Usuario");

            //modelBuilder.Entity<Atividade>().ToTable("Atividade");
            //modelBuilder.Entity<FuncaoProjeto>().ToTable("FuncaoProjeto");
            //modelBuilder.Entity<Projeto>().ToTable("Projeto");
            //modelBuilder.Entity<SituacaoProjeto>().ToTable("SituacaoProjeto");
            //modelBuilder.Entity<Tarefa>().ToTable("Tarefa");

            //modelBuilder.Entity<ColunaKanban>().ToTable("ColunaKanban");
            //modelBuilder.Entity<QuadroKanban>().ToTable("QuadroKanban");
            //modelBuilder.Entity<Sprint>().ToTable("Sprint");
            //modelBuilder.Entity<TipoColunaKanban>().ToTable("TipoColunaKanban");
        }
    }
}
