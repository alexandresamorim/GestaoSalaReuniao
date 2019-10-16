using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Interface.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        ValidationResult Adicionar(TEntity entity);
        void Alterar(TEntity entity);
        void Remover(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}