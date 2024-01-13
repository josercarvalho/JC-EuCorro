using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            // Primary Key
            HasKey(t => t.EstadoId);

            // Properties
            Property(t => t.Sigla)
                .HasMaxLength(100);

            Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Estado");
            Property(t => t.EstadoId).HasColumnName("EstadoId");
            Property(t => t.PaisId).HasColumnName("PaisId");
            Property(t => t.Sigla).HasColumnName("Sigla");
            Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            HasRequired(t => t.Pais)
                .WithMany(t => t.Estados)
                .HasForeignKey(d => d.PaisId);    
        }
    }
}
