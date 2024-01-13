using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class ModalidadeMap : EntityTypeConfiguration<Modalidade>
    {
        public ModalidadeMap()
        {
            // Primary Key
            HasKey(t => t.ModalidadeId);

            // Properties
            Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Modalidade");
            Property(t => t.ModalidadeId).HasColumnName("ModalidadeId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Distancia).HasColumnName("Distancia");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");

            // Relationships
        }
    }
}
