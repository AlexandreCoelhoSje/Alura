using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Autorizacao
{
    [Table("Funcao")]
    public class Funcao
    {
        public int FuncaoID { get; set; }
        public string Descricao { get; set; }
    }
}
