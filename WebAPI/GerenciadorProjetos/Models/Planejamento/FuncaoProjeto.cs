using GerenciadorProjetos.Models.Autorizacao;
using GerenciadorProjetos.Models.Identidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorProjetos.Models.Planejamento
{
    [Table("FuncaoProjeto")]
    public class FuncaoProjeto
    {
        public int FuncaoProjetoID { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public int ProjetoID { get; set; }
        public Projeto Projeto { get; set; }

        public int FuncaoID { get; set; }
        public Funcao Funcao { get; set; }
    }
}