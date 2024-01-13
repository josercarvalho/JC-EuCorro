using EuCorro.Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EuCorro.Security.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("EuCorroConnection", throwIfV1Schema: false)
        {

        }

        //public DbSet<Categoria> Categorias { get; set; }
        //public DbSet<Cidade> Cidade { get; set; }
        //public DbSet<Empresa> Empresas { get; set; }
        //public DbSet<EntregaKit> EntregaKit { get; set; }
        //public DbSet<Estado> Estados { get; set; }
        //public DbSet<Evento> Eventos { get; set; }
        //public DbSet<EventoKit> EventoKits { get; set; }
        //public DbSet<EventoTipo> EventoTipos { get; set; }
        //public DbSet<Galeria> Galerias { get; set; }
        //public DbSet<Inscricoes> Inscricoes { get; set; }
        //public DbSet<Modalidade> Modalidades { get; set; }
        //public DbSet<ModalidadeEvento> ModalidadeEventos { get; set; }
        //public DbSet<ModalidadePreco> ModalidadePrecos { get; set; }
        //public DbSet<NumeroDoPeito> NumeroDoPeito { get; set; }
        //public DbSet<Pais> Pais { get; set; }
        //public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        //public DbSet<PerguntasAdicionais> PerguntasAdicionais { get; set; }
        //public DbSet<PontoDeVendas> PontoDeVendas { get; set; }
        //public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Client> Client { get; set; }   
        public DbSet<Claims> Claims { get; set; }  

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UsuarioMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

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

        //public System.Data.Entity.DbSet<EuCorro.Domain.Models.Evento> Eventoes { get; set; }

        //public System.Data.Entity.DbSet<EuCorro.Domain.Models.EventoTipo> EventoTipoes { get; set; }

        //public System.Data.Entity.DbSet<EuCorro.Domain.Models.Modalidade> Modalidades { get; set; }

        //public System.Data.Entity.DbSet<EuCorro.MVC.Site.ViewModels.InscricaoViewmodel> InscricaoViewmodels { get; set; }
    }
}
