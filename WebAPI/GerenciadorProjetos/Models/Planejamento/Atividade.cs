using GerenciadorProjetos.Models.Scrum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorProjetos.Models.Planejamento
{
    [Table("Atividade")]
    public class Atividade
    {
        public int AtividadeID { get; set; }

        [Required]
        public string CodigoIdentificador { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public double NumeroOrdenacao { get; set; }

        [MaxLength(500), MinLength(1)]
        public string ValoresEsforco { get; set; }

        public double EsforcoEstimado { get; set; }

        public double EsforcoReal { get; set; }

        public int ProjetoID { get; set; }
        public Projeto Projeto { get; set; }
        
        public int? SprintID { get; set; }
        public Sprint Sprint { get; set; }

        public int? ColunaKanbanID { get; set; }
        public ColunaKanban ColunaKanban { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}