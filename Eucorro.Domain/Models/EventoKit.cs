namespace EuCorro.Domain.Models
{
    public class EventoKit
    {

        public int EventoKitId { get; set; }
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Tamanho_PP { get; set; }
        public int Tamanho_P { get; set; }
        public int Tamanho_M { get; set; }
        public int Tamanho_G { get; set; }
        public int Tamanho_GG { get; set; }
        public int Tamanho_XG { get; set; }

        public virtual Evento Evento { get; set; }
        //public virtual EventoKit EventoKit1 { get; set; }
        //public virtual EventoKit EventoKit2 { get; set; }
    }
}
