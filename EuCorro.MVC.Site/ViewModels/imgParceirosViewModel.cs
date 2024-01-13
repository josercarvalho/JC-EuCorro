using System.ComponentModel.DataAnnotations;

namespace EuCorro.MVC.Site.ViewModels
{
    public class imgParceirosViewModel
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }

    }
}