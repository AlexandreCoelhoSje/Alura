using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.ModeloProjeto
{
    [Table("SituacaoProjeto")]
    public class SituacaoProjeto
    {
        public int SituacaoProjetoID { get; set; }

        public string Descricao { get; set; }
    }
}
