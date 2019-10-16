using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Repository;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Service
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public ValidationResult Adicionar(Sala entity)
        {
            var resultadoValidacao = new ValidationResult();
            if (!entity.IsValid())
            {
                resultadoValidacao.AdicionarErro(entity.ResultadoValidacao);
                return resultadoValidacao;
            }
            _salaRepository.Adicionar(entity);
            return resultadoValidacao;

        }

        public void Alterar(Sala entity)
        {
            _salaRepository.Alterar(entity);
        }

        public void Remover(Sala entity)
        {
            _salaRepository.Remover(entity);
        }

        public Sala GetById(Guid id)
        {
            return _salaRepository.GetById(id);
        }

        public IEnumerable<Sala> GetAll()
        {
            return _salaRepository.GetAll();
        }

        public IEnumerable<Sala> GetByDescricao(string descricao)
        {
            return _salaRepository.GetByDescricao(descricao);
        }
    }
}