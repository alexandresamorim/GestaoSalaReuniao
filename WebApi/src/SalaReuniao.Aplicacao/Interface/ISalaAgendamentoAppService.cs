using System;
using System.Collections.Generic;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;

namespace SalaReuniao.Aplicacao.Interface
{
    public interface ISalaAgendamentoAppService
    {
        ValidationAppResult Adicionar(SalaAgendamentoViewModel salaAgendamentoView);
        void Editar(SalaAgendamentoViewModel salaAgendamentoView);
        void Excluir(SalaAgendamentoViewModel salaAgendamentoView);
        IEnumerable<SalaAgendamentoViewModel> ObterPorData(Guid salaGuid, DateTime data);
    }
}