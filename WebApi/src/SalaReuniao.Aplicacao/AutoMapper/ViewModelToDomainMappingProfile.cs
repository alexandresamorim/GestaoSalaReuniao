using AutoMapper;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<SalaViewModel, Sala>();
            CreateMap<SalaGradeViewModel, SalaGrade>();
            CreateMap<SalaAgendamentoViewModel, SalaAgendamento>();
        }
    }
}
