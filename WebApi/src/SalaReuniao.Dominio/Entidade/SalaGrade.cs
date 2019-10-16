using System;

namespace SalaReuniao.Dominio.Entidade
{
    public class SalaGrade
    {
        public Guid SalaGradeId { get; set; }
        public Guid SalaId { get; set; }
        public int DiaSemana { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
    }
}