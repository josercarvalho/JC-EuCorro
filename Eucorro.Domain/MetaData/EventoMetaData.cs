using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class EventoMetaData
    {
        public int EventoId { get; set; }
        public int EventoTipoId { get; set; }
        public int ModalidadeId { get; set; }

        [Required]
        [Display(Name = "Data Evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataEvento { get; set; }

        [Required]
        [Display(Name = "Hora Evento")]
        public string HoraEvento { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Título do Evento")]
        public string TituloEvento { get; set; }
        public string PastaFiles { get; set; }

        [Display(Name = "URL dos resultados")]
        public string URL { get; set; }

        [Display(Name = "Fone do Contato")]
        public string FoneContato { get; set; }

        [Display(Name = "E-mail do Contato")]
        public string EmailContato { get; set; }

        public int Instritos { get; set; }

        [Required]
        [Display(Name = "Data Encerra")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataEncerramento { get; set; }

        [Required]
        [Display(Name = "Data Encerramento")]
        public string HoraEncerramento { get; set; }

        [Required]
        [Display(Name = "Endereço do Evento")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [Required]
        [Display(Name = "Descrição detalhada do Evento")]
        public string DescricaoEvento { get; set; }

        [Required]
        public string Regulamento { get; set; }

        [Required]
        [Display(Name = "Informações sobre o KIT")]
        public string InformacaoKit { get; set; }

        [Display(Name = "Imagem do KIT")]
        public string ImagemKit { get; set; }

        [Display(Name = "Banner do Evento")]
        public string BannerEvento { get; set; }

        [Display(Name = "Banner do Patrocinador")]
        public string BannerPatrocinio { get; set; }
        public bool Ativo { get; set; }
        public int Status { get; set; }

        //public virtual int? PontoDeVenda_PontoDeVendasId { get; set; }

        //public virtual int? Inscricoes_InscricoesId { get; set; }
    }
}
