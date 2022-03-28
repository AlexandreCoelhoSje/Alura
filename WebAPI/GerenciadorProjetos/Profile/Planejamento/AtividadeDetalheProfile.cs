using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class AtividadeDetalheProfile : AutoMapper.Profile
    {
        public AtividadeDetalheProfile()
        {
            CreateMap<Atividade, AtividadeDetalheDTO>()
                .ForMember(dest => 
                    dest.ProjetoDescricao, 
                    opt => opt.MapFrom(src => src.Projeto == null ? "" : src.Projeto.Descricao))
            .ReverseMap()
                .ForMember(dest =>
                    dest.Projeto,
                    opt => opt.Ignore());
        }
    }
}
