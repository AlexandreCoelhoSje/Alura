using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorProjetos.Models.ModeloProjeto;

namespace GerenciadorProjetos.Models.Scrum
{
    [Table("QuadroKanban")]
    public class QuadroKanban
    {
        public int QuadroKanbanID { get; set; }

        public Projeto Projeto { get; set; }

        public ICollection<ColunaKanban> ColunasKanban { get; set; }
    }
}
