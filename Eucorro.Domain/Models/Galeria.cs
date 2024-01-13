namespace EuCorro.Domain.Models
{
    public class Galeria 
    {
        public int GaleriaId { get; set; }
        public int EventoId { get; set; }       
        public string Descricao { get; set; }    
        public string Pasta { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
