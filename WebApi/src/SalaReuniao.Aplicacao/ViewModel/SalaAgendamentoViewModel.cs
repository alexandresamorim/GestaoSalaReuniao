using System;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Aplicacao.ViewModel
{
    public class SalaAgendamentoViewModel
    {
        public SalaAgendamentoViewModel()
        {
            SalaAgendamentoId = Guid.NewGuid();
        }
        public Guid SalaAgendamentoId { get; set; }
        public Guid SalaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}