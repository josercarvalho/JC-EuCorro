using EuCorro.Domain.Enum;
using EuCorro.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EuCorro.Security.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Clients = new Collection<Client>();
            Inscricoes = new List<Inscricoes>();
            PontoDeVendas = new List<PontoDeVendas>();
        }

        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public Brasileiro Brasileiro { get; set; }
        public Sexo Sexo { get; set; }
        public Camiseta Camiseta { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Contato { get; set; }
        public string FoneContato { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int PaisId { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string WhatsApp { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual int PerfilUsuarioId { get; set; }
        //public virtual int? PontoDeVenda_PontoDeVendasId { get; set; }
        //public virtual int? Inscricoes_InscricoesId { get; set; }

        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<PontoDeVendas> PontoDeVendas { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        [NotMapped]
        public string CurrentClientId { get; set; }
        //public string NameIdentifier { get; set; }

        public DateTime? ActiveUntil;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, ClaimsIdentity ext = null)
        {
            // Observe que o authenticationType precisa ser o mesmo que foi definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(CurrentClientId))
            {
                claims.Add(new Claim("AspNet.Identity.ClientId", CurrentClientId));
            }

            //  Adicione novos Claims aqui //
            claims.Add(new Claim("AdmClains", "True"));

            // Adicionando Claims externos capturados no login
            if (ext != null)
            {
                SetExternalProperties(userIdentity, ext);
            }

            // Gerenciamento de Claims para informaçoes do usuario
            claims.Add(new Claim("AdmRoles", "True"));

            userIdentity.AddClaims(claims);

            return userIdentity;
        }

        private void SetExternalProperties(ClaimsIdentity identity, ClaimsIdentity ext)
        {
            if (ext != null)
            {
                var ignoreClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims";
                // Adicionando Claims Externos no Identity
                foreach (var c in ext.Claims)
                {
                    if (!c.Type.StartsWith(ignoreClaim))
                        if (!identity.HasClaim(c.Type, c.Value))
                            identity.AddClaim(c);
                }
            }
        }
    }

       
}
