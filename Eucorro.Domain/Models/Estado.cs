using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class Estado
    {
        public Estado()
        {
            this.Cidades = new List<Cidade>();
            this.Empresas = new List<Empresa>();
        }

        public int EstadoId { get; set; }
        public int PaisId { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
