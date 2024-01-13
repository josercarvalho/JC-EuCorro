using System;

namespace EuCorro.Domain.Models
{
    public class EntregaKit 
    {
        public int EntregaKitId { get; set; }
        public int EventoId { get; set; }
        public string UserId { get; set; }
        public string CPFRecebedor { get; set; }
        public string NomeRecebedor { get; set; }
        public int NumeroDoPeito { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Status { get; set; } // 0 - Aberto, 1 - Entregue

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
