using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class ModalidadePrecoMap : EntityTypeConfiguration<ModalidadePreco>
    {

        public ModalidadePrecoMap()
        {
            // Primary Key
            this.HasKey(t => t.ModalidadePrecoId);

            // Properties
            this.Property(t => t.HoraIni)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.HoraFin)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CodigoDesconto)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("ModalidadePreco");
            this.Property(t => t.ModalidadePrecoId).HasColumnName("ModalidadePrecoId");
            this.Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            this.Property(t => t.TipoIncricao).HasColumnName("TipoIncricao");
            this.Property(t => t.DtInicial).HasColumnName("DtInicial");
            this.Property(t => t.DtFinal).HasColumnName("DtFinal");
            this.Property(t => t.HoraIni).HasColumnName("HoraIni");
            this.Property(t => t.HoraFin).HasColumnName("HoraFin");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.ValorDesconto).HasColumnName("ValorDesconto");
            this.Property(t => t.Desconto).HasColumnName("Desconto");
            this.Property(t => t.CodigoDesconto).HasColumnName("CodigoDesconto");
            this.Property(t => t.ValidadeDesconto).HasColumnName("ValidadeDesconto");
            this.Property(t => t.ModalidadeEvento_ModalidadeEventoId).HasColumnName("ModalidadeEvento_ModalidadeEventoId");
            this.Property(t => t.ModalidadeEvento_ModalidadeEventoId1).HasColumnName("ModalidadeEvento_ModalidadeEventoId1");


            // Relationships
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.ModalidadePrecos)
                .HasForeignKey(d => d.ModalidadeEventoId);
            HasRequired(t => t.ModalidadeEvento1)
                .WithMany(t => t.ModalidadePrecos1)
                .HasForeignKey(d => d.ModalidadeEventoId);
        }
    }
}
