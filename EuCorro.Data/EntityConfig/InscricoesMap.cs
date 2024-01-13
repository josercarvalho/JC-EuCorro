using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class InscricoesMap : EntityTypeConfiguration<Inscricoes>
    {
        public InscricoesMap()
        {
            // Primary Key
            this.HasKey(t => t.InscricoesId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            this.Property(t => t.ToKen)
                .HasMaxLength(128);

            this.Property(t => t.TipoPagamento)
                .HasMaxLength(50);

            //this.Property(t => t.UserId1)
            //    .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Inscricoes");
            this.Property(t => t.InscricoesId).HasColumnName("InscricoesId");
            this.Property(t => t.EventoId).HasColumnName("EventoId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ModalidadeEventoId).HasColumnName("ModalidadeEventoId");
            this.Property(t => t.ToKen).HasColumnName("ToKen");
            this.Property(t => t.TipoPagamento).HasColumnName("TipoPagamento");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.ValorServico).HasColumnName("ValorServico");
            this.Property(t => t.ValorBoleto).HasColumnName("ValorBoleto");
            this.Property(t => t.ValorTotal).HasColumnName("ValorTotal");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            //this.Property(t => t.ModalidadeCategoria_ModalidadeCategoriaId).HasColumnName("ModalidadeCategoria_ModalidadeCategoriaId");
            //this.Property(t => t.UserId1).HasColumnName("UserId1");

            // Relationships
            HasRequired(t => t.Evento)
                .WithMany(t => t.Inscricoes)
                .HasForeignKey(d => d.EventoId);
            HasRequired(t => t.ModalidadeEvento)
                .WithMany(t => t.Inscricoes)
                .HasForeignKey(d => d.ModalidadeEventoId);
            HasRequired(t => t.Usuario)
                .WithMany(t => t.Inscricoes)
                .HasForeignKey(d => d.UserId);
            HasOptional(t => t.ModalidadeCategoria)
                .WithMany(t => t.Inscricoes)
                .HasForeignKey(d => d.ModalidadeCategoria_ModalidadeCategoriaId);
            //HasRequired(t => t.Usuario1)
            //     .WithMany(t => t.Inscricoes)
            //     .HasForeignKey(d => d.UserId1);
            //HasRequired(t => t.ModalidadeCategoria)
            //    .WithMany(t => t.Inscricoes)
            //    .HasForeignKey(d => d.ModalidadeCategoria);
        }
    }
}
