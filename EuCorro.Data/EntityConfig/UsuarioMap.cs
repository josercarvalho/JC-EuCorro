using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            HasKey(u => u.Id);

            // Properties
            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.CPF)
                .IsRequired()
                .HasMaxLength(15);

            Property(t => t.Foto)
                .HasMaxLength(150);

            Property(t => t.DataNascimento)
                .IsRequired();

            Property(t => t.Contato)
                .HasMaxLength(100);

            Property(t => t.FoneContato)
                .HasMaxLength(20);

            Property(t => t.Endereco)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.Complemento)
                .HasMaxLength(150);

            Property(t => t.Bairro)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.CEP)
                .IsRequired()
                .HasMaxLength(15);

            Property(t => t.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Celular)
                .HasMaxLength(20);

            Property(t => t.WhatsApp)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("AspNetUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Foto).HasColumnName("Foto");
            this.Property(t => t.Brasileiro).HasColumnName("Brasileiro");
            this.Property(t => t.Sexo).HasColumnName("Sexo");
            this.Property(t => t.Camiseta).HasColumnName("Camiseta");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.Idade).HasColumnName("Idade");
            this.Property(t => t.Contato).HasColumnName("Contato");
            this.Property(t => t.FoneContato).HasColumnName("FoneContato");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.PaisId).HasColumnName("PaisId");
            this.Property(t => t.CidadeId).HasColumnName("CidadeId");
            this.Property(t => t.EstadoId).HasColumnName("EstadoId");
            //this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.WhatsApp).HasColumnName("WhatsApp");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.NameIdentifier).HasColumnName("NameIdentifier");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.Senha).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.Telefone).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PerfilUsuarioId).HasColumnName("PerfilUsuarioId");

            // Relationships
            //this.HasOptional(t => t.Inscricoes)
            //    .WithMany()
            //    .HasForeignKey(d => d.Inscricoes_InscricoesId);
            //this.HasOptional(t => t.Inscritos)
            //    .WithMany()
            //    .HasForeignKey(d => d.Inscritos_InscritosId);
            //this.HasOptional(t => t.PerfilUsuario)
            //    .WithMany()
            //    .HasForeignKey(d => d.PerfilUsuarioId);
            //this.HasOptional(t => t.PontoDeVendas)
            //    .WithMany()
            //    .HasForeignKey(d => d.PontoDeVendas_PontoDeVendasId);
        }
    }
}
