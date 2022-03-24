using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Dto.Planejamento
{
    public class AtividadeDTO
    {
        public int AtividadeID { get; set; }
        public string CodigoIdentificador { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public double NumeroOrdenacao { get; set; }
        public string ValoresEsforco { get; set; }
        public double EsforcoEstimado { get; set; }
        public double EsforcoReal { get; set; }

        public ICollection<TarefaDTO> Tarefas { get; set; }

        //public Sprint SprintDTO { get; set; }

        //public ColunaKanbanDTO ColunaKanban { get; set; }
    }
}
