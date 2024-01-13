using EuCorro.Domain.Models;

namespace EuCorro.MVC.Site.ViewModels
{
    public class ModalidadeEventoViewModel
    {
        public int ModalidadeEventoId { get; set; }
        public string NomeEvento { get; set; }
        public ModalidadeEvento Modalidade { get; set; }
    }
}