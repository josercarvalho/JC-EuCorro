using EuCorro.Domain.Models;
using EuCorro.Data.EntityConfig;
using EuCorro.Security.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EuCorro.Data.Context
{
    public class EuCorroContext :  DbContext
    {
        public EuCorroContext()
            : base("EuCorroConnection")
        {

        }

        //public DbSet<CamisetasKits> CamisetasKits { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EntregaKit> EntregaKit { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoKit> EventoKits { get; set; }
        public DbSet<EventoTipo> EventoTipos { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<Inscricoes> Inscricoes { get; set; }
        public DbSet<Inscritos> Inscritos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<ModalidadeCategoria> ModalidadeCategorias { get; set; }
        public DbSet<ModalidadeEvento> ModalidadeEventos { get; set; }
        public DbSet<ModalidadePreco> ModalidadePrecos { get; set; }
        public DbSet<NumeroDoPeito> NumeroDoPeito { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<PerguntasAdicionais> PerguntasAdicionais { get; set; }
        public DbSet<PontoDeVendas> PontoDeVendas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Dependentes> Dependentes { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Claims> Claims { get; set; }             

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CamisetasKitMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new EntregaKitMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new EventoKitMap());
            modelBuilder.Configurations.Add(new EventoTipoMap());
            modelBuilder.Configurations.Add(new GaleriaMap());
            modelBuilder.Configurations.Add(new InscricoesMap());
            modelBuilder.Configurations.Add(new InscritosMap());
            modelBuilder.Configurations.Add(new ModalidadeMap());
            modelBuilder.Configurations.Add(new ModalidadeEventoMap());
            modelBuilder.Configurations.Add(new ModalidadePrecoMap());
            modelBuilder.Configurations.Add(new NumeroDoPeitoMap());
            modelBuilder.Configurations.Add(new PaisMap());
            modelBuilder.Configurations.Add(new ModalidadeCategoriaMap());
            modelBuilder.Configurations.Add(new PerguntasAdicionaiMap());
            modelBuilder.Configurations.Add(new PontoDeVendaMap());
            modelBuilder.Configurations.Add(new PerfilUsuarioMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new DependentesMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(128));

            modelBuilder.Properties<string>()
                .Where(p => p.Name.Contains("Descricao"))
                .Configure(p => p.IsMaxLength());

            modelBuilder.Properties<string>()
                .Where(p => p.Name.Contains("UF"))
                .Configure(p => p.HasMaxLength(2));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
