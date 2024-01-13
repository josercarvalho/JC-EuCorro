using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class PerguntasAdicionaiMap : EntityTypeConfiguration<PerguntasAdicionais>
    {
        public PerguntasAdicionaiMap()
        {
            // Primary Key
            HasKey(t => t.PerguntasAdicionaisId);

            // Properties
            Property(t => t.TipCampo)
                .HasMaxLength(100);

            Property(t => t.Pergunta)
                .HasMaxLength(100);

            Property(t => t.TextoAjuda)
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("PerguntasAdicionais");
            Property(t => t.PerguntasAdicionaisId).HasColumnName("PerguntasAdicionaisId");
            Property(t => t.TipCampo).HasColumnName("TipCampo");
            Property(t => t.EventoId).HasColumnName("EventoId");
            Property(t => t.Obrigatorio).HasColumnName("Obrigatorio");
            Property(t => t.Pergunta).HasColumnName("Pergunta");
            Property(t => t.TextoAjuda).HasColumnName("TextoAjuda");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.PerguntasAdicionais)
                .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.PerguntasAdicionais)
                .HasForeignKey(d => d.ModalidadeEventoId);
        }
    }
}
