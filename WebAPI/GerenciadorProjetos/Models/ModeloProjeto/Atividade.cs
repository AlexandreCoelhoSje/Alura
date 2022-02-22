using GerenciadorProjetos.Models.Scrum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.ModeloProjeto
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

        [Required]
        public Projeto Projeto { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
        
        public Sprint Sprint { get; set; }

        public ColunaKanban ColunaKanban { get; set; }
    }
}
