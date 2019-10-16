using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Service
{
    public class SalaAgendamentoService : ISalaAgendamentoService
    {
        private readonly ISalaAgendamentoRepository _agendamentoRepository;

        public SalaAgendamentoService(ISalaAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public ValidationResult Adicionar(SalaAgendamento entity)
        {
            var resultadoValidacao = new ValidationResult();
            if (!entity.IsValid())
            {
                resultadoValidacao.AdicionarErro(entity.ResultadoValidacao);
                return resultadoValidacao;
            }
            _agendamentoRepository.Adicionar(entity);
            return resultadoValidacao;
        }

        public void Alterar(SalaAgendamento entity)
        {
            _agendamentoRepository.Alterar(entity);
        }

        public void Remover(SalaAgendamento entity)
        {
            _agendamentoRepository.Remover(entity);
        }

        public SalaAgendamento GetById(Guid id)
        {
            return _agendamentoRepository.GetById(id);
        }

        public IEnumerable<SalaAgendamento> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalaAgendamento> ObterPorData(Guid salaId, DateTime data)
        {
            return _agendamentoRepository.ObterPorData(salaId, data);
        }

        public IEnumerable<SalaAgendamento> ObterPorIntervalo(Guid salaId, DateTime dataHoraInicio, DateTime datahoraFinal)
        {
            return _agendamentoRepository.ObterPorIntervalo(salaId, dataHoraInicio, datahoraFinal);
        }
    }
}