

using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Interface.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}