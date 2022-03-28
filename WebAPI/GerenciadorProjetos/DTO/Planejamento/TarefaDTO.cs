using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Dto.Planejamento
{
    public class TarefaDTO
    {
        public int TarefaID { get; set; }
        public string Descricao { get; set; }
        public double? Ordem { get; set; }
        public int AtividadeID { get; set; }
    }
}
