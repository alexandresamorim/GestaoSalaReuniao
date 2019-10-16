using System;
using System.Linq;
using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.Interface.Specification;
using SalaReuniao.Dominio.Service;

namespace SalaReuniao.Dominio.Specification
{
    public class AgendamentoDisponivelSpecification : ISpecification<SalaAgendamento>
    {
        public bool IsSatisfiedBy(SalaAgendamento entity)
        {
            var agendamentoService = ServiceLocator.Current.GetInstance<ISalaAgendamentoService>();
            var dataHoraInicio = entity.Data.AddHours(entity.HoraInicio.TimeOfDay.Hours).AddMinutes(entity.HoraInicio.TimeOfDay.Minutes);
            var dataHoraFinal = entity.Data.AddHours(entity.HoraFinal.TimeOfDay.Hours).AddMinutes(entity.HoraFinal.TimeOfDay.Minutes);

            return !agendamentoService.ObterPorIntervalo(entity.SalaId, dataHoraInicio, dataHoraFinal).Any();
        }
    }
}