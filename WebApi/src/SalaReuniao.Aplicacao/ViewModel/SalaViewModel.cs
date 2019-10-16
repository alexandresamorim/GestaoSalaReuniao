using System;
using System.Collections;
using System.Collections.Generic;
using SalaReuniao.Dominio.Entidade;

namespace SalaReuniao.Aplicacao.ViewModel
{
    public class SalaViewModel
    {
        public SalaViewModel()
        {
            SalaId = Guid.NewGuid();
        }
        public Guid SalaId { get; set; }
        public int Situacao { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<SalaGradeViewModel> SalaGrades { get; set; }
    }
}