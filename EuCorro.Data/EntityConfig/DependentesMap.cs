using EuCorro.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class DependentesMap : EntityTypeConfiguration<Dependentes>
    {
        public DependentesMap()
        {
            // Primary Key
            this.HasKey(t => t.DependenteId);

            // Properties
            this.Property(t => t.DependenteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Documento)
                .HasMaxLength(50);

            this.Property(t => t.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Contato)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.FoneContato)
                .IsRequired()
                .HasMaxLength(20);

            //this.Property(t => t.UserId1)
            //    .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Dependentes");
            this.Property(t => t.DependenteId).HasColumnName("DependenteId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.Documento).HasColumnName("Documento");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Sexo).HasColumnName("Sexo");
            this.Property(t => t.Contato).HasColumnName("Contato");
            this.Property(t => t.FoneContato).HasColumnName("FoneContato");
            //this.Property(t => t.UserId1).HasColumnName("UserId1");

            // Relationships
            HasRequired(t => t.Usuario)
                .WithMany(t => t.Dependentes)
                .HasForeignKey(d => d.UserId);
        }
    }
}
