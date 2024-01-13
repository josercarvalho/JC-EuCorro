using Eucorro.Domain.MetaData;
using EuCorro.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(InscritosMetaData))]
    public class Inscritos
    {
        public Inscritos()
        {
            Usuarios = new List<Usuario>();
        }

        public int InscritosId { get; set; }
        public int InscricoesId { get; set; }
        public int EventoId { get; set; }
        public string UserId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public int ModalidadeCategoriaId { get; set; }
        public Camiseta Camiseta { get; set; }
        public decimal Valor { get; set; }
        public bool DescontoIdoso { get; set; }
        public decimal ValorServico { get; set; }
        public decimal ValorBoleto { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Inscricoes Inscricoes { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento { get; set; }
        public virtual ModalidadeCategoria ModalidadeCategoria { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
