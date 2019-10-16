using SalaReuniao.Aplicacao.Validation;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Aplicacao.Service
{
    public class BaseAppService
    {
        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}