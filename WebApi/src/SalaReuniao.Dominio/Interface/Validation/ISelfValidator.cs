using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Interface.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid();
    }
}