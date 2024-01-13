using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.MVC.Site.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ListaBannerViewModel> ListaBanner { get; set; }
        public IEnumerable<Inscricoes> Participantes { get; set; }
        public IEnumerable<Evento> ProximosEventos { get; set; }
        public int Cadastrados { get; set; }
        public int Inscritos { get; set; }
        public IEnumerable<Usuario> Aniversariantes { get; set; }
    }
}