using EuCorro.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.MVC.Site.ViewModels
{
    public class EventoViewModel
    {
        public class ListaModalidade
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Distancia { get; set; }

            

            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
            public decimal Valor { get; set; }

        }

        public string Ano { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }

        public Evento Evento { get; set; }
        public IEnumerable<ListaModalidade> Modalidades { get; set; }

    }

    
}