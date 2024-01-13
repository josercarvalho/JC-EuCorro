namespace EuCorro.Domain.Models
{
    public class PerguntasAdicionais 
    {
        public int PerguntasAdicionaisId { get; set; }
        public string TipCampo { get; set; }
        public int EventoId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public bool Obrigatorio { get; set; }
        public string Pergunta { get; set; }
        public string TextoAjuda { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento { get; set; }
    }
}
