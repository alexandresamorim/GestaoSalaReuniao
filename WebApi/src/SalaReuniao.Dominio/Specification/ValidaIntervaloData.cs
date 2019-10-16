using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Interface.Specification;

namespace SalaReuniao.Dominio.Specification
{
    public class ValidaIntervaloData : ISpecification<SalaAgendamento>
    {
        public bool IsSatisfiedBy(SalaAgendamento entity)
        {
            return entity.HoraFinal > entity.HoraInicio;
        }
    }
}