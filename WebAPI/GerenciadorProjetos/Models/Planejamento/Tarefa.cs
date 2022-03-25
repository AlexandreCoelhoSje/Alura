using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Planejamento
{
    [Table("Tarefa")]
    public class Tarefa
    {
        public int TarefaID { get; set; }

        [Required]
        public string Descricao { get; set; }

        public double? Ordem { get; set; }

        public int AtividadeID { get; set; }
        public Atividade Atividade { get; set; }
    }
}
