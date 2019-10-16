using SalaReuniao.Dominio.Entidade;
using SalaReuniao.Dominio.Specification;

namespace SalaReuniao.Dominio.Validation
{
    public class AvendamentoValidation : FiscalBase<SalaAgendamento>
    {
        public AvendamentoValidation()
        {
            base.AdicionarRegra(new Regra<SalaAgendamento>(new ValidaIntervaloData(), "Intervalo entre as horas é inválido"));
            base.AdicionarRegra(new Regra<SalaAgendamento>(new AgendamentoDisponivelSpecification(), "Já existe um agendamento nesse intervalo de horas"));
        }
    }
}