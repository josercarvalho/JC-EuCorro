using EuCorro.Domain.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(EventoMetaData))]
    public class Evento 
    {
        public Evento()
        {
            EntregaKits = new List<EntregaKit>();
            EventoKits = new List<EventoKit>();
            Galerias = new List<Galeria>();
            Inscricoes = new List<Inscricoes>();
            ModalidadeEventos = new List<ModalidadeEvento>();
            NumeroDoPeito = new List<NumeroDoPeito>();
            PerguntasAdicionais = new List<PerguntasAdicionais>();
            Inscritos = new List<Inscritos>();
            PontoDeVendas = new List<PontoDeVendas>();
        }

        public int EventoId { get; set; }
        public int EventoTipoId { get; set; }
        public int ModalidadeId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataEvento { get; set; }
        public string HoraEvento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string TituloEvento { get; set; }
        public string PastaFiles { get; set; }
        public string URL { get; set; }
        public string FoneContato { get; set; }
        public string EmailContato { get; set; }
        public int Instritos { get; set; }
        public DateTime DataEncerramento { get; set; }
        public string HoraEncerramento { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public string DescricaoEvento { get; set; }
        public string Regulamento { get; set; }
        public string InformacaoKit { get; set; }
        public string ImagemKit { get; set; }
        public string BannerEvento { get; set; }
        public string BannerPatrocinio { get; set; }
        public bool Ativo { get; set; } // True - Ativo para o Site, False - Inativo para o site.
        public int Status { get; set; } // 0 - Evento Futuro, 1 - Inscrições Abertas, 2 - Inscrições Encerradas, 3 - Inativo
        //public virtual int? PontoDeVenda_PontoDeVendasId { get; set; }
        //public virtual int? PontoDeVendas_PontoDeVendasId { get; set; }
        //public virtual int? Inscricoes_InscricoesId { get; set; }

        public virtual EventoTipo EventoTipo { get; set; }
        public virtual Modalidade Modalidade { get; set; }
        public virtual PontoDeVendas PontoDeVenda { get; set; }
        public virtual Categoria Categpria { get; set; }
        public virtual ICollection<EntregaKit> EntregaKits { get; set; }
        public virtual ICollection<EventoKit> EventoKits { get; set; }
        public virtual ICollection<Galeria> Galerias { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<ModalidadeEvento> ModalidadeEventos { get; set; }
        public virtual ICollection<NumeroDoPeito> NumeroDoPeito { get; set; }
        public virtual ICollection<PerguntasAdicionais> PerguntasAdicionais { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }
        public virtual ICollection<PontoDeVendas> PontoDeVendas { get; set; }
        //public virtual ICollection<PontoDeVendas> PontoDeVendas1 { get; set; }

    }
}
