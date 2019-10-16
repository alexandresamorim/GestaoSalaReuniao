using System;
using System.Collections.Generic;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;

namespace SalaReuniao.Aplicacao.Interface
{
    public interface ISalaAppService
    {
        ValidationAppResult Adicionar(SalaViewModel salaViewModel);
        void Editar(SalaViewModel salaViewModel);
        void Excluir(SalaViewModel salaViewModel);
        IEnumerable<SalaViewModel> ObterTodas();
        SalaViewModel ObterPorId(Guid id);
    }
}