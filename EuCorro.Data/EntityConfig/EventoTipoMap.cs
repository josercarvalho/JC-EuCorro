using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EventoTipoMap : EntityTypeConfiguration<EventoTipo>
    {
        public EventoTipoMap()
        {
            // Primary Key
            HasKey(t => t.EventoTipoId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(150);

            // Table & Column Mappings
            ToTable("EventoTipo");
            Property(t => t.EventoTipoId).HasColumnName("EventoTipoId");
            Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
        }
    }
}
