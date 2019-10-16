using System;
using SalaReuniao.Dominio.Interface.Validation;
using SalaReuniao.Dominio.Validation;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Entidade
{
    public class SalaAgendamento : ISelfValidator
    {
        public Guid SalaAgendamentoId { get; set; }
        public Guid SalaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public Usuario Usuario { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }

        public bool IsValid()
        {
            var fisco = new AvendamentoValidation();
            ResultadoValidacao = fisco.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}