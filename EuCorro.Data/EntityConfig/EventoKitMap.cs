using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EventoKitMap : EntityTypeConfiguration<EventoKit>
    {
        public EventoKitMap()
        {
            // Primary Key
            HasKey(t => t.EventoKitId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(150);

            Property(t => t.Descricao)
                .HasMaxLength(8000);

            // Table & Column Mappings
            ToTable("EventoKit");
            Property(t => t.EventoKitId).HasColumnName("EventoKitId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Valor).HasColumnName("Valor");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Tamanho_PP).HasColumnName("Tamanho_PP");
            Property(t => t.Tamanho_P).HasColumnName("Tamanho_P");
            Property(t => t.Tamanho_M).HasColumnName("Tamanho_M");
            Property(t => t.Tamanho_G).HasColumnName("Tamanho_G");
            Property(t => t.Tamanho_GG).HasColumnName("Tamanho_GG");
            Property(t => t.Tamanho_XG).HasColumnName("Tamanho_XG");

            // Relationships
            //HasRequired(t => t.EventoKit2)
            //    .WithOptional(t => t.EventoKit1);
            //HasOptional(t => t.Evento)
            //    .WithMany(t => t.EventoKits)
            //    .HasForeignKey(d => d.EventoId);
        }
    }
}
