using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Dominio.Interface.Repository
{
    public interface ISalaAgendamentoRepository : IRepositoryBase<SalaAgendamento>
    {
        IEnumerable<SalaAgendamento> ObterPorData(Guid salaId, DateTime data);
        IEnumerable<SalaAgendamento> ObterPorIntervalo(Guid salaId, DateTime dataHoraInicio, DateTime datahoraFinal);
    }
}