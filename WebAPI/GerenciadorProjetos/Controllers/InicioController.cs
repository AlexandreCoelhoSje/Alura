using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]
        public ActionResult Inicio()
        {

            return Ok(new { mensagem = "Olá mundo" });
        }

        //[HttpGet]
        //[Authorize(Roles = "employee,manager")]
        //public ActionResult Inicio2()
        //{

        //    return Ok(new { nome = User.Identity.Name });
        //}
    }
}
