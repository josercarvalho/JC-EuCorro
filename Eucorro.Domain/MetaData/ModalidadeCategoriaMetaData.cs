using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class ModalidadeCategoriaMetaData
    {
        [Key]
        public int ModalidadeCategoriaId { get; set; }

        public int ModalidadeEventoId { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public int Desconto { get; set; }
    }
}
