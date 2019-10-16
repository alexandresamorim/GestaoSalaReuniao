using System;
using System.Collections.Generic;

namespace SalaReuniao.Dominio.Interface.Repository
{
    public interface IRepositoryBase<Entity>
    {
        void Adicionar(Entity entity);
        void Alterar(Entity entity);
        void Remover(Entity entity);
        Entity GetById(Guid id);
        IEnumerable<Entity> GetAll();
    }
}