using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class NumeroDoPeitoMap : EntityTypeConfiguration<NumeroDoPeito>
    {
        public NumeroDoPeitoMap()
        {
            // Primary Key
            HasKey(t => t.NumeroDoPeitoId);

            // Properties
            // Table & Column Mappings
            ToTable("NumeroDoPeito");
            Property(t => t.NumeroDoPeitoId).HasColumnName("NumeroDoPeitoId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            Property(t => t.NumeroIni).HasColumnName("NumeroIni");
            Property(t => t.NumeroFin).HasColumnName("NumeroFin");
            Property(t => t.Total).HasColumnName("Total");
            Property(t => t.NumeroAtual).HasColumnName("NumeroAtual");
            Property(t => t.TipoNumeracao).HasColumnName("TipoNumeracao");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.NumeroDoPeito)
                .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.NumeroDoPeito)
                .HasForeignKey(d => d.ModalidadeEventoId);
        }
    }
}
