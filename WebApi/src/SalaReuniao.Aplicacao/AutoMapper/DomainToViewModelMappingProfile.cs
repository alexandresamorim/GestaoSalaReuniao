using AutoMapper;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ValidationResult, ValidationAppResult>();
            CreateMap<ValidationError, ValidationAppError>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Sala, SalaViewModel>();
            CreateMap<SalaGrade, SalaGradeViewModel>();
            CreateMap<SalaAgendamento, SalaAgendamentoViewModel>();
        }
    }
}
