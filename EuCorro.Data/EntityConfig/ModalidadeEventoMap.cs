using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class ModalidadeEventoMap : EntityTypeConfiguration<ModalidadeEvento>
    {
        public ModalidadeEventoMap()
        {
            // Primary Key
            HasKey(t => t.ModalidadeEventoId);

            // Properties
            Property(t => t.Percurso)
                .HasMaxLength(8000);

            Property(t => t.PercursoImg)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("ModalidadeEvento");
            Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.ModalidadeId).HasColumnName("ModalidadeId");
            Property(t => t.Reverzamento).HasColumnName("Reverzamento");
            Property(t => t.AtletasPorEquipe).HasColumnName("AtletasPorEquipe");
            Property(t => t.Vagas).HasColumnName("Vagas");
            Property(t => t.NumeroInicial).HasColumnName("NumeroInicial");
            Property(t => t.NumeroFinal).HasColumnName("NumeroFinal");
            Property(t => t.IdadeMin).HasColumnName("IdadeMin");
            Property(t => t.IdadeMax).HasColumnName("IdadeMax");
            Property(t => t.Percurso).HasColumnName("Percurso");
            Property(t => t.PercursoImg).HasColumnName("PercursoImg");
            Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            Property(t => t.ModalidadePreco_ModalidadePrecoId).HasColumnName("ModalidadePreco_ModalidadePrecoId");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.ModalidadeEventos)
                .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.Modalidade)
                .WithMany(t => t.ModalidadeEventos)
                .HasForeignKey(d => d.ModalidadeId);
            HasOptional(t => t.ModalidadePreco)
                .WithMany(t => t.ModalidadeEventos)
                .HasForeignKey(d => d.ModalidadePreco_ModalidadePrecoId);
        }
    }
}
