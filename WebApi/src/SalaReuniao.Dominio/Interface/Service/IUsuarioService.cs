using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Dominio.Interface.Service
{
    public interface IUsuarioService :  IServiceBase<Usuario>
    {
        Usuario ObterPorEmail(string email);
    }
}