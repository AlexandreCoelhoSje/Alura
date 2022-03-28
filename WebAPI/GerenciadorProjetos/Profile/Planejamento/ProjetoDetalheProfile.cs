using AutoMapper;
using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class ProjetoDetalheProfile : AutoMapper.Profile
    {
        public ProjetoDetalheProfile()
        {
            CreateMap<Projeto, ProjetoDetalheDTO>()
                .ReverseMap()
                    .ForMember(dest =>
                            dest.SituacaoProjeto,
                            opt => opt.Ignore());
        }
    }
}
