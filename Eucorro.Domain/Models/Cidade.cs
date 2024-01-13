using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class Cidade 
    {
        public Cidade()
        {
            this.Empresas = new List<Empresa>();
        }

        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
