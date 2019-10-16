using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SalaReuniao.Aplicacao.Interface;
using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Aplicacao.ViewModel;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;

namespace SalaReuniao.Aplicacao.Service
{
    public class SalaAppService : BaseAppService, ISalaAppService
    {
        private readonly IMapper _mapper;
        private readonly ISalaService _salaService;

        public SalaAppService(IMapper mapper, ISalaService salaService)
        {
            _mapper = mapper;
            _salaService = salaService;
        }

        public ValidationAppResult Adicionar(SalaViewModel salaViewModel)
        {
            var sala = _mapper.Map<Sala>(salaViewModel);
            var result = _salaService.Adicionar(sala);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            return DomainToApplicationResult(result);
        }

        public void Editar(SalaViewModel salaViewModel)
        {
            var sala = _mapper.Map<Sala>(salaViewModel);
            _salaService.Alterar(sala);
        }

        public void Excluir(SalaViewModel salaViewModel)
        {
            var sala = _mapper.Map<Sala>(salaViewModel);
            _salaService.Remover(sala);
        }

        public IEnumerable<SalaViewModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<SalaViewModel>>(_salaService.GetAll());
        }

        public SalaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<SalaViewModel>(_salaService.GetById(id));
        }
    }
}