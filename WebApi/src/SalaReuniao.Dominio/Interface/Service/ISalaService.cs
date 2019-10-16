using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Dominio.Interface.Service
{
    public interface ISalaService : IServiceBase<Sala>
    {
        IEnumerable<Sala> GetByDescricao(string descricao);
    }
}