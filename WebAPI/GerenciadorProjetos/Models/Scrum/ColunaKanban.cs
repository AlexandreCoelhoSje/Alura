using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Scrum
{
    [Table("ColunaKanban")]
    public class ColunaKanban
    {
        public int ColunaKanbanID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public int Ordem { get; set; }

        public QuadroKanban QuadroKanban { get; set; }

        public TipoColunaKanban TipoColunaKanban { get; set; }
    }
}
