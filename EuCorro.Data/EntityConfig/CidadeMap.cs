using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            // Primary Key
            HasKey(t => t.CidadeId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Cidade");
            Property(t => t.CidadeId).HasColumnName("CidadeId");
            Property(t => t.EstadoId).HasColumnName("EstadoId");
            Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            HasRequired(t => t.Estado)
                .WithMany(t => t.Cidades)
                .HasForeignKey(d => d.EstadoId);

        }
    }
}
