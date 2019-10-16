using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Specification;

namespace SalaReuniao.Dominio.Validation
{
    public class UsuarioValidation : FiscalBase<Usuario>
    {
        public UsuarioValidation()
        {
            base.AdicionarRegra(new Regra<Usuario>(new UsuarioEmailJaCadastradoSpecification(), "Email já cadastrado"));
        }
    }
}