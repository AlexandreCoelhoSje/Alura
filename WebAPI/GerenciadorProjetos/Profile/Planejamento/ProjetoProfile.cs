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
            CreateMap<Projeto, ProjetoDTO>()
                .ForMember(dest =>
                    dest.totalAtividade,
                    opt => opt.MapFrom(src => src.Atividades.Count()))
            .ReverseMap()
                .ForMember(dest =>
                        dest.SituacaoProjeto,
                        opt => opt.Ignore());
        }
    }
}
