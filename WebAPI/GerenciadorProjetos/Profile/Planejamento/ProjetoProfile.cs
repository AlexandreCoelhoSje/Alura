using AutoMapper;
using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class ProjetoProfile : AutoMapper.Profile
    {
        public ProjetoProfile()
        {
            CreateMap<Projeto, ProjetoDTO>().ReverseMap();
            //.ForMember(dest =>
            //    dest.totalAtividade,
            //    opt => opt.MapFrom(src => src.Atividades.Count())) ;
        }
    }
}
