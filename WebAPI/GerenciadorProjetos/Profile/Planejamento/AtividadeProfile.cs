using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class AtividadeProfile : AutoMapper.Profile
    {
        public AtividadeProfile()
        {
            CreateMap<Atividade, AtividadeDTO>();
        }
    }
}
