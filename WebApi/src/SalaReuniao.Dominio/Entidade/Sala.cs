using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Interface.Validation;
using SalaReuniao.Dominio.Validation;
using SalaReuniao.Dominio.ValueObjects;

namespace SalaReuniao.Dominio.Entidade
{
    public class Sala : ISelfValidator
    {
        public Guid SalaId { get; set; }
        public int Situacao { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<SalaGrade> SalaGrades { get; set; }
        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            var fisco = new SalaValidation();
            ResultadoValidacao = fisco.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}