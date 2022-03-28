using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Dto.Planejamento
{
    public class ProjetoDetalheDTO
    {
        public int ProjetoID { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public int SituacaoProjetoID { get; set; }
        public SituacaoProjetoDTO SituacaoProjeto { get; set; }
    }
}