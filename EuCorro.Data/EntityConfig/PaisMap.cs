using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public PaisMap()
        {
            // Primary Key
            HasKey(t => t.PaisId);

            // Properties
            Property(t => t.Sigla)
                .HasMaxLength(100);

            Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Pais");
            Property(t => t.PaisId).HasColumnName("PaisId");
            Property(t => t.Sigla).HasColumnName("Sigla");
            Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
