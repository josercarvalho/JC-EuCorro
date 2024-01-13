using EuCorro.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace EuCorro.Data.EntityConfig
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            // Primary Key
            this.HasKey(t => t.EventoId);

            // Properties
            this.Property(t => t.HoraEvento)
                .HasMaxLength(10);

            this.Property(t => t.Nome)
                .HasMaxLength(150);

            this.Property(t => t.TituloEvento)
                .HasMaxLength(150);

            this.Property(t => t.PastaFiles)
                .HasMaxLength(70);

            this.Property(t => t.URL)
                .HasMaxLength(100);

            this.Property(t => t.FoneContato)
                .HasMaxLength(100);

            this.Property(t => t.EmailContato)
                .HasMaxLength(100);

            this.Property(t => t.HoraEncerramento)
                .HasMaxLength(10);

            this.Property(t => t.Endereco)
                .HasMaxLength(100);

            this.Property(t => t.Regulamento)
                .HasMaxLength(100);

            this.Property(t => t.InformacaoKit)
                .HasMaxLength(100);

            this.Property(t => t.ImagemKit)
                .HasMaxLength(100);

            this.Property(t => t.BannerEvento)
                .HasMaxLength(100);

            this.Property(t => t.BannerPatrocinio)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Evento");
            this.Property(t => t.EventoId).HasColumnName("EventoId");
            this.Property(t => t.EventoTipoId).HasColumnName("EventoTipoId");
            this.Property(t => t.ModalidadeId).HasColumnName("ModalidadeId");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            this.Property(t => t.DataEvento).HasColumnName("DataEvento");
            this.Property(t => t.HoraEvento).HasColumnName("HoraEvento");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.TituloEvento).HasColumnName("TituloEvento");
            this.Property(t => t.PastaFiles).HasColumnName("PastaFiles");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.FoneContato).HasColumnName("FoneContato");
            this.Property(t => t.EmailContato).HasColumnName("EmailContato");
            this.Property(t => t.Instritos).HasColumnName("Instritos");
            this.Property(t => t.DataEncerramento).HasColumnName("DataEncerramento");
            this.Property(t => t.HoraEncerramento).HasColumnName("HoraEncerramento");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.EstadoId).HasColumnName("EstadoId");
            this.Property(t => t.CidadeId).HasColumnName("CidadeId");
            this.Property(t => t.DescricaoEvento).HasColumnName("DescricaoEvento");
            this.Property(t => t.Regulamento).HasColumnName("Regulamento");
            this.Property(t => t.InformacaoKit).HasColumnName("InformacaoKit");
            this.Property(t => t.ImagemKit).HasColumnName("ImagemKit");
            this.Property(t => t.BannerEvento).HasColumnName("BannerEvento");
            this.Property(t => t.BannerPatrocinio).HasColumnName("BannerPatrocinio");
            this.Property(t => t.Ativo).HasColumnName("Ativo");
            this.Property(t => t.Status).HasColumnName("Status");
            //this.Property(t => t.PontoDeVenda_PontoDeVendasId).HasColumnName("PontoDeVenda_PontoDeVendasId");
            //this.Property(t => t.PontoDeVendas_PontoDeVendasId).HasColumnName("PontoDeVendas_PontoDeVendasId");

            // Relationships
            HasRequired(t => t.EventoTipo)
                .WithMany(t => t.Eventos)
                .HasForeignKey(d => d.EventoTipoId);
            HasRequired(t => t.Modalidade)
                .WithMany(t => t.Eventos)
                .HasForeignKey(d => d.ModalidadeId);
            //HasOptional(t => t.Categpria)
            //    .WithMany(t => t.Eventos)
            //    .HasForeignKey(d => d.CategoriaId);
        }
    }
}
