using System;

namespace EuCorro.MVC.Site.ViewModels
{
    public class ListaBannerViewModel
    {
        public int EventoId { get; set; }
        public string Banner { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string HoraEvento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public String URL { get; set; }
        public TimeSpan Previsao { get; set; }
    }
}