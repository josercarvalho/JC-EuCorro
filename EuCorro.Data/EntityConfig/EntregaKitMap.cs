using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EntregaKitMap : EntityTypeConfiguration<EntregaKit>
    {
        public EntregaKitMap()
        {
            // Primary Key
            this.HasKey(t => t.EntregaKitId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            this.Property(t => t.CPFRecebedor)
                .HasMaxLength(100);

            this.Property(t => t.NomeRecebedor)
                .HasMaxLength(100);

            // Properties
            // Table & Column Mappings
            ToTable("EntregaKit");
            Property(t => t.EntregaKitId).HasColumnName("EntregaKitId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.CPFRecebedor).HasColumnName("CPFRecebedor");
            Property(t => t.NomeRecebedor).HasColumnName("NomeRecebedor");
            Property(t => t.NumeroDoPeito).HasColumnName("NumeroDoPeito");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            Property(t => t.Status).HasColumnName("Status");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.EntregaKits)
                .HasForeignKey(d => d.EventoId);
            HasOptional(t => t.Usuario)
                .WithMany(t => t.EntregaKits)
                .HasForeignKey(d => d.UserId);
        }
    }
}
