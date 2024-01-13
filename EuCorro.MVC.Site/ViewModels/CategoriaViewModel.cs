namespace EuCorro.MVC.Site.ViewModels
{
    public class CategoriaViewModel
    {
        public int ModalidadeCategoriaId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public string CategoriaDescricao { get; set; }
        public int CategoriaDesconto { get; set; } // 0 = REAL | 1 = PERCENTUAL
    }
}