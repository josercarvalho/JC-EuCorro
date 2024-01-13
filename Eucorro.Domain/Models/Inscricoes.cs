using EuCorro.Domain.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(InscricoesMetaData))]       
    public class Inscricoes 
    {
        public Inscricoes()
        {
            Usuarios = new List<Usuario>();
            Inscritos = new List<Inscritos>();
        }

        public int InscricoesId { get; set; }
        public int EventoId { get; set; }
        public string UserId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public string ToKen { get; set; }
        public string TipoPagamento { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorServico { get; set; }
        public decimal ValorBoleto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ModalidadeCategoria_ModalidadeCategoriaId { get; set; }
        //public string UserId1 { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
        //public virtual Usuario Usuario1 { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento { get; set; }
        public virtual ModalidadeCategoria ModalidadeCategoria { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
