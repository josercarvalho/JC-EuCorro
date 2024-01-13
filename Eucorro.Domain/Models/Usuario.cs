using EuCorro.Domain.Enum;
using EuCorro.Domain.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(UsuarioMetaData))]
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
            PontoDeVendas = new List<PontoDeVendas>();
            Inscricoes = new List<Inscricoes>();
            EntregaKits = new List<EntregaKit>();
            Dependentes = new List<Dependentes>();
            Inscritos = new List<Inscritos>();
        }

        public string Id { get; set; }
        public virtual int PerfilUsuarioId { get; set; }
        public string Nome { get; set; }
        public string NameIdentifier { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string Senha { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string Telefone { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual string UserName { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Foto { get; set; }
        public virtual Brasileiro Brasileiro { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Camiseta Camiseta { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual int Idade { get; set; }
        public virtual string Contato { get; set; }
        public virtual string FoneContato { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string CEP { get; set; }
        public virtual int PaisId { get; set; }
        public virtual int CidadeId { get; set; }
        public virtual int EstadoId { get; set; }
        public virtual string Celular { get; set; }
        public virtual string WhatsApp { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        public virtual ICollection<PontoDeVendas> PontoDeVendas { get; set; }
        public virtual ICollection<Dependentes> Dependentes { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<EntregaKit> EntregaKits { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }

        public void ChecarAtleta()
        {
            var mensagem = new List<string>();

            if (string.IsNullOrEmpty(UserName) || UserName.Trim().Length == 0)
                mensagem.Add("Nome inválido");

            if (DataNascimento == new DateTime())
                mensagem.Add("Nascimento inválido");

            if (mensagem.Count > 0)
                throw new Exception(string.Join(" | ", mensagem));
        }

        public int IdadeAtleta(Usuario user)
        {
            return DateTime.Now.Year - user.DataNascimento.Year;
        }
    }
}
