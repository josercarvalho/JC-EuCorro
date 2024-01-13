using EuCorro.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class ModalidadeCategoriaMap : EntityTypeConfiguration<ModalidadeCategoria>
    {
        public ModalidadeCategoriaMap()
        {
            // Primary Key
            HasKey(t => t.ModalidadeCategoriaId);

            // Properties
            Property(t => t.ModalidadeCategoriaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Descricao)
                .HasMaxLength(100);
            
            // Table & Column Mappings
            ToTable("ModalidadeCategoria");
            Property(t => t.ModalidadeCategoriaId).HasColumnName("ModalidadeCategoriaId");
            //Property(t => t.ModalidadeCategoriaId).HasColumnName("ModalidadeCategoriaId");
            Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Desconto).HasColumnName("Desconto");

            // Relationships
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.ModalidadeCategorias)
                .HasForeignKey(d => d.ModalidadeEventoId);
        }
    }
}
