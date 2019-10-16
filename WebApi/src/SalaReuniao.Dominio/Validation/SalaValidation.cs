using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Specification;

namespace SalaReuniao.Dominio.Validation
{
    public class SalaValidation : FiscalBase<Sala>
    {
        public SalaValidation()
        {
            base.AdicionarRegra(new Regra<Sala>(new SalaJaExisteSpecification(), "Sala já existente"));
        }
    }
}