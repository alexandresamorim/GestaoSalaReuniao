using System;
using SalaReuniao.Dominio.Interface.Validation;
using SalaReuniao.Dominio.Validation;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Entidade
{
    public class Usuario : ISelfValidator
    {
        public Guid UsuarioId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string LoggedOn { get; set; }
        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            var fisco = new UsuarioValidation();
            ResultadoValidacao = fisco.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}