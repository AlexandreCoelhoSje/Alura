using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Scrum
{
    [Table("Sprint")]
    public class Sprint
    {
        public int SprintID { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Observacao { get; set; }

        [Required]
        public DateTime DataInicial { get; set; }

        [Required]
        public DateTime DataFinal { get; set; }

        [Required]
        public Projeto Projeto { get; set; }
    }
}
