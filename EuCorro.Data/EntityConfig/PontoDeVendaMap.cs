using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class PontoDeVendaMap : EntityTypeConfiguration<PontoDeVendas>
    {
        public PontoDeVendaMap()
        {
            // Primary Key
            HasKey(t => t.PontoDeVendasId);

            // Properties
            Property(t => t.Local)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("PontoDeVendas");
            Property(t => t.PontoDeVendasId).HasColumnName("PontoDeVendasId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.Local).HasColumnName("Local");
            //Property(t => t.Evento_EventoId).HasColumnName("Evento_EventoId");
            //Property(t => t.Evento_EventoId1).HasColumnName("Evento_EventoId1");
            //Property(t => t.UserId1).HasColumnName("UserId1");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.PontoDeVendas)
                .HasForeignKey(d => d.EventoId);
            //HasRequired(t => t.Evento1)
            //    .WithMany(t => t.PontoDeVendas1)
            //    .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.Usuario)
                .WithMany(t => t.PontoDeVendas)
                .HasForeignKey(d => d.UserId);
            //HasRequired(t => t.Usuario1)
            //    .WithMany(t => t.PontoDeVendas)
            //    .HasForeignKey(d => d.UserId1);
        }
    }
}
