using System.Linq;
using CommonServiceLocator;
using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Service;
using SalaReuniao.Dominio.Interface.Specification;

namespace SalaReuniao.Dominio.Specification
{
    public class SalaJaExisteSpecification : ISpecification<Sala>
    {
        public bool IsSatisfiedBy(Sala entity)
        {
            var salaService = ServiceLocator.Current.GetInstance<ISalaService>();
            return !salaService.GetByDescricao(entity.Descricao).Any();
        }
    }
}