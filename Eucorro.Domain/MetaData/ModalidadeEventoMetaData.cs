using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class ModalidadeEventoMetaData
    {
        [Key]
        public int ModalidadeEventoId { get; set; }
        public int EventoId { get; set; }
        public int ModalidadeId { get; set; }
        public bool Reverzamento { get; set; }
        public int AtletasPorEquipe { get; set; }

        [Required]
        public int Vagas { get; set; }

        [Required]
        [Display(Name = "Número Inicial")]
        public int NumeroInicial { get; set; }

        [Required]
        [Display(Name = "Número Final")]
        public int NumeroFinal { get; set; }

        [Required]
        [Display(Name = "Idade Mínima")]
        public int IdadeMin { get; set; }

        [Required]
        [Display(Name = "Idade Máxima")]
        public int IdadeMax { get; set; }

        [Required]
        [Display(Name = "Descrição do Percurso")]
        public string Percurso { get; set; }

        [Display(Name = "Imagem do Percurso")]
        public string PercursoImg { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
    }
}
