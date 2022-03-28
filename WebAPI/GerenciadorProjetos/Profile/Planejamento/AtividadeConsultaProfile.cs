using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class AtividadeConsultaProfile : AutoMapper.Profile
    {
        public AtividadeConsultaProfile()
        {
            CreateMap<Atividade, AtividadeConsultaDTO>()
                .ForMember(dest => 
                    dest.ProjetoDescricao, 
                    opt => opt.MapFrom(src => src.Projeto.Descricao));
        }
    }
}
