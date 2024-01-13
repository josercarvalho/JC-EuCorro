using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class InscritosMap : EntityTypeConfiguration<Inscritos>
    {
        public InscritosMap()
        {
            // Primary Key
            HasKey(t => t.InscritosId);

            // Properties
            Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("Inscritos");
            Property(t => t.InscritosId).HasColumnName("InscritosId");
            Property(t => t.InscricoesId).HasColumnName("InscricoesId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            Property(t => t.Camiseta).HasColumnName("Camiseta");
            Property(t => t.Valor).HasColumnName("Valor");
            Property(t => t.DescontoIdoso).HasColumnName("DescontoIdoso");
            Property(t => t.ValorServico).HasColumnName("ValorServico");
            Property(t => t.ValorBoleto).HasColumnName("ValorBoleto");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");

            // Relationships
            HasRequired(t => t.Usuario)
                .WithMany(t => t.Inscritos)
                .HasForeignKey(d => d.UserId);
            //HasRequired(t => t.Usuario1)
            //    .WithMany(t => t.Inscritos)
            //    .HasForeignKey(d => d.UserId1);
            HasRequired(t => t.Evento)
                .WithMany(t => t.Inscritos)
                .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.Inscricoes)
                .WithMany(t => t.Inscritos)
                .HasForeignKey(d => d.InscricoesId);
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.Inscritos)
                .HasForeignKey(d => d.ModalidadeEventoId);
            HasRequired(t => t.ModalidadeCategoria)
                .WithMany(t => t.Inscritos)
                .HasForeignKey(d => d.ModalidadeCategoriaId);
        }
    }
}
