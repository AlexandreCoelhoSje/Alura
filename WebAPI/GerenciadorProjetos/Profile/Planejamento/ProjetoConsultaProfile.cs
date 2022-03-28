using AutoMapper;
using GerenciadorProjetos.Dto.Planejamento;
using GerenciadorProjetos.Models.Planejamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorProjetos.Profile.Planejamento
{
    public class ProjetoConsultaProfile : AutoMapper.Profile
    {
        public ProjetoConsultaProfile()
        {
            CreateMap<Projeto, ProjetoConsultaDTO>()
                .ForMember(dest =>
                    dest.totalAtividades,
                    opt => opt.MapFrom(src => src.Atividades.Count()))
                .ForMember(dest =>
                    dest.atividadesAFazer,
                    opt => opt.MapFrom(src => src.Atividades.Where(atv => atv.ColunaKanban != null ? atv.ColunaKanban.TipoColunaKanban.TipoColunaKanbanID == 1 : false ).Count() ))
                .ForMember(dest =>
                    dest.atividadesFazendo,
                    opt => opt.MapFrom(src => src.Atividades.Where(atv => atv.ColunaKanban != null ? atv.ColunaKanban.TipoColunaKanban.TipoColunaKanbanID == 2 : false ).Count()))
                .ForMember(dest =>
                    dest.atividadesFeitas,
                    opt => opt.MapFrom(src => src.Atividades.Where(atv => atv.ColunaKanban != null ? atv.ColunaKanban.TipoColunaKanban.TipoColunaKanbanID == 3 : false ).Count()))
            .ReverseMap()
                .ForMember(dest =>
                        dest.SituacaoProjeto,
                        opt => opt.Ignore());
        }
    }
}
