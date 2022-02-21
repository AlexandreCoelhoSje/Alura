using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.ModeloProjeto
{
    [Table("Projeto")]
    public class Projeto
    {
        public int ProjetoID  { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        public string Descricao { get; set; }

        public string Resumo { get; set; }

        [Required]
        public DateTime DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }

        [Required]
        public SituacaoProjeto SituacaoProjeto { get; set; }

        public ICollection<Atividade> Atividades { get; set; }
    }
}
