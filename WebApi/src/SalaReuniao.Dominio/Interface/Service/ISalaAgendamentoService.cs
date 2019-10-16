using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Interface.Service
{
    public interface ISalaAgendamentoService : IServiceBase<SalaAgendamento>
    {
        IEnumerable<SalaAgendamento> ObterPorData(Guid salaId, DateTime data);
        IEnumerable<SalaAgendamento> ObterPorIntervalo(Guid salaId, DateTime dataHoraInicio, DateTime datahoraFinal);
    }
}