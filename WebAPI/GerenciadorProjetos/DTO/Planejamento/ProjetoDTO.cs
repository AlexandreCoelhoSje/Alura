using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Dto.Planejamento
{
    public class ProjetoDTO
    {
        public int ProjetoID { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public int SituacaoProjetoID { get; set; }
        public SituacaoProjetoDTO SituacaoProjeto { get; set; }

        //public ICollection<AtividadeDTO> Atividades { get; set; }

        //public int totalAtividade { get; set; }
        //public int totalAtividadeFeita { get; set; }
        //public int totalAtividadeFazendo { get; set; }
        //public int totalAtividadeAFazer { get; set; }
    }
}