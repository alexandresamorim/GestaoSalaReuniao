using CommonServiceLocator;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.Interface.Specification;

namespace SalaReuniao.Dominio.Specification
{
    public class UsuarioEmailJaCadastradoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario entity)
        {
            var usuarioService = ServiceLocator.Current.GetInstance<IUsuarioService>();

            return usuarioService.ObterPorEmail(entity.Email) == null;
        }
    }
}