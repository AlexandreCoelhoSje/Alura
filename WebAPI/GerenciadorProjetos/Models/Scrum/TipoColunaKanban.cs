using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Scrum
{
    [Table("TipoColunaKanban")]
    public class TipoColunaKanban
    {
        public int TipoColunaKanbanID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public bool ExibirQuadro { get; set; }
    }
}
