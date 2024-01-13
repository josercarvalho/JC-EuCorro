using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            HasKey(t => t.EmpresaId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(100);

            Property(t => t.Telefone)
                .HasMaxLength(100);

            Property(t => t.Responsavel)
                .HasMaxLength(100);

            Property(t => t.Celular)
                .HasMaxLength(100);

            Property(t => t.CEP)
                .HasMaxLength(100);

            Property(t => t.Bairro)
                .HasMaxLength(100);

            Property(t => t.Logradouro)
                .HasMaxLength(100);

            Property(t => t.Numero)
                .HasMaxLength(100);

            Property(t => t.Complemento)
                .HasMaxLength(100);

            Property(t => t.Endereco)
                .HasMaxLength(200);

            Property(t => t.Latitude)
                .HasMaxLength(50);

            Property(t => t.Longitude)
                .HasMaxLength(50);

            Property(t => t.Email)
                .HasMaxLength(100);

            Property(t => t.CNPJ)
                .HasMaxLength(100);

            Property(t => t.Avatar)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Empresa");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Telefone).HasColumnName("Telefone");
            Property(t => t.Responsavel).HasColumnName("Responsavel");
            Property(t => t.Celular).HasColumnName("Celular");
            Property(t => t.CEP).HasColumnName("CEP");
            Property(t => t.PaisId).HasColumnName("PaisId");
            Property(t => t.EstadoId).HasColumnName("EstadoId");
            Property(t => t.CidadeId).HasColumnName("CidadeId");
            Property(t => t.Bairro).HasColumnName("Bairro");
            Property(t => t.Logradouro).HasColumnName("Logradouro");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Complemento).HasColumnName("Complemento");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.CNPJ).HasColumnName("CNPJ");
            Property(t => t.Avatar).HasColumnName("Avatar");

            // Relationships
            HasRequired(t => t.Cidades)
                .WithMany(t => t.Empresas)
                .HasForeignKey(d => d.CidadeId);

            HasRequired(t => t.Estados)
                .WithMany(t => t.Empresas)
                .HasForeignKey(d => d.EstadoId);

            HasRequired(t => t.Paises)
                .WithMany(t => t.Empresas)
                .HasForeignKey(d => d.PaisId);
        }
    }
}
