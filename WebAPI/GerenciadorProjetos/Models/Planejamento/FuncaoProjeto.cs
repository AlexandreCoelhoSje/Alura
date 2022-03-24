using GerenciadorProjetos.Models.Autorizacao;
using GerenciadorProjetos.Models.Identidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Planejamento
{
    [Table("FuncaoProjeto")]
    public class FuncaoProjeto
    {
        public int FuncaoProjetoID { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public Projeto Projeto { get; set; }

        [Required]
        public Funcao Funcao { get; set; }
    }
}
