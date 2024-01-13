using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class GaleriaMap : EntityTypeConfiguration<Galeria>
    {
        public GaleriaMap()
        {
            // Primary Key
            HasKey(t => t.GaleriaId);

            // Properties
            Property(t => t.Descricao)
                .HasMaxLength(150);

            Property(t => t.Pasta)
                .HasMaxLength(150);

            // Table & Column Mappings
            ToTable("Galeria");
            Property(t => t.GaleriaId).HasColumnName("GaleriaId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Pasta).HasColumnName("Pasta");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.Galerias)
                .HasForeignKey(d => d.EventoId);

        }
    }
}
