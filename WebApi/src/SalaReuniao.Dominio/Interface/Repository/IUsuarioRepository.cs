using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Dominio.Interface.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPorEmail(string email);
    }
}