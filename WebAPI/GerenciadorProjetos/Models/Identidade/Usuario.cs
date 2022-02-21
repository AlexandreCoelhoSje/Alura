using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Models.Identidade
{
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200), MinLength(3)]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(15), MinLength(5)]
        public string Senha { get; set; }
    }
}
