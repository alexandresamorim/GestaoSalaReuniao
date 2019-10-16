using System;
using System.Collections.Generic;
using AutoMapper;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;

namespace SalaReuniao.Aplicacao.Service
{
    public class SalaAgendamentoAppService : BaseAppService, ISalaAgendamentoAppService
    {
        private readonly IMapper _mapper;
        private readonly ISalaAgendamentoService _agendamentoService;

        public SalaAgendamentoAppService(IMapper mapper, ISalaAgendamentoService agendamentoService)
        {
            _mapper = mapper;
            _agendamentoService = agendamentoService;
        }

        public ValidationAppResult Adicionar(SalaAgendamentoViewModel salaAgendamentoView)
        {
            var salaAgendamento = _mapper.Map<SalaAgendamento>(salaAgendamentoView);

            var result = _agendamentoService.Adicionar(salaAgendamento);
            if (!result.IsValid)
                return DomainToApplicationResult(result);


            return DomainToApplicationResult(result);

        }

        public void Editar(SalaAgendamentoViewModel salaAgendamentoView)
        {
            var salaAgendamento = _mapper.Map<SalaAgendamento>(salaAgendamentoView);
            _agendamentoService.Alterar(salaAgendamento);
        }

        public void Excluir(SalaAgendamentoViewModel salaAgendamentoView)
        {
            var salaAgendamento = _mapper.Map<SalaAgendamento>(salaAgendamentoView);
            _agendamentoService.Remover(salaAgendamento);
        }

        public IEnumerable<SalaAgendamentoViewModel> ObterPorData(Guid salaId, DateTime data)
        {
            return _mapper.Map<IEnumerable<SalaAgendamentoViewModel>>(_agendamentoService.ObterPorData(salaId, data));
        }
    }
}