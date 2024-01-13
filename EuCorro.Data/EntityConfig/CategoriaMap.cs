using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            // Primary Key
            HasKey(t => t.CategoriaId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(100);

            Property(t => t.Descricao)
                .HasMaxLength(8000);

            // Table & Column Mappings
            ToTable("Categoria");
            Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.TipoDesconto).HasColumnName("TipoDesconto");
            Property(t => t.Desconto).HasColumnName("Desconto");

            // Relationships
        }
    }
}
