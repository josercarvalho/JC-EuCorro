using System;
using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class PerfilUsuario
    {
        public PerfilUsuario()
        {
            Usuarios = new List<Usuario>();
            //ModulosAcesso = new List<ModulosAcesso>();
        }
        public int PerfilUsuarioId { get; set; }
        public string NomPerfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool FlAdminMaster { get; set; }
        public bool FlUserMaster { get; set; }
        public bool FlOperador { get; set; }
        public bool FlAtivo { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        //public virtual ICollection<ModulosAcesso> ModulosAcesso { get; set; }
    }
}
