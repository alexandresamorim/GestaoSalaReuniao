using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Dominio.Interface.Repository
{
    public interface ISalaRepository : IRepositoryBase<Sala>
    {
        IEnumerable<Sala> GetByDescricao(string descricao);
    }
}