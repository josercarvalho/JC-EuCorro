using EuCorro.Domain.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(ModalidadeEventoMetaData))]
    public class ModalidadeEvento 
    {
        public ModalidadeEvento()
        {
            EntregaKits = new List<EntregaKit>();
            Inscricoes = new List<Inscricoes>();
            Inscritos = new List<Inscritos>();
            ModalidadePrecos = new List<ModalidadePreco>();
            ModalidadePrecos1 = new List<ModalidadePreco>();
            NumeroDoPeito = new List<NumeroDoPeito>();
            PerguntasAdicionais = new List<PerguntasAdicionais>();
            ModalidadeCategorias = new List<ModalidadeCategoria>();
        }

        public int ModalidadeEventoId { get; set; }
        public int EventoId { get; set; }
        public int ModalidadeId { get; set; }
        public bool Reverzamento { get; set; }
        public int AtletasPorEquipe { get; set; }
        public int Vagas { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public string Percurso { get; set; }
        public string PercursoImg { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ModalidadePreco_ModalidadePrecoId { get; set; }

        public virtual Evento Evento { get; set; }        
        public virtual Modalidade Modalidade { get; set; }
        public virtual ModalidadePreco ModalidadePreco { get; set; }

        public virtual ICollection<EntregaKit> EntregaKits { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }
        public virtual ICollection<ModalidadeCategoria> ModalidadeCategorias { get; set; }
        public virtual ICollection<ModalidadePreco> ModalidadePrecos { get; set; }
        public virtual ICollection<ModalidadePreco> ModalidadePrecos1 { get; set; }
        public virtual ICollection<NumeroDoPeito> NumeroDoPeito { get; set; }
        public virtual ICollection<PerguntasAdicionais> PerguntasAdicionais { get; set; }
    }
}
