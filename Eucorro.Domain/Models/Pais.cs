using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class Pais
    {
        public Pais()
        {
            Estados = new List<Estado>();
            Empresas = new List<Empresa>();
        }

        public int PaisId { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Estado> Estados { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}
