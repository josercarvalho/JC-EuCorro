using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class PerfilUsuarioMap : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.PerfilUsuarioId);

            // Properties
            this.Property(t => t.NomPerfil)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PerfilUsuario");
            this.Property(t => t.PerfilUsuarioId).HasColumnName("PerfilUsuarioId");
            this.Property(t => t.NomPerfil).HasColumnName("NomPerfil");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.FlAdminMaster).HasColumnName("FlAdminMaster");
            this.Property(t => t.FlUserMaster).HasColumnName("FlUserMaster");
            this.Property(t => t.FlOperador).HasColumnName("FlOperador");
            this.Property(t => t.FlAtivo).HasColumnName("FlAtivo");
        }
    }
}
