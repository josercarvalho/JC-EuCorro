using System;
using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class ModulosAcesso
    {
        public ModulosAcesso()
        {
            PerfisUsuario = new List<PerfilUsuario>();
        }
        public int ModuloId { get; set; }
        public string NomeModulo { get; set; }
        public string NomeMenuAcesso { get; set; }
        public string UrlMenu { get; set; }
        public bool FlAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ModuloPaiId { get; set; }
        public virtual ModulosAcesso ModulosAcessos { get; set; }
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
    }
}
