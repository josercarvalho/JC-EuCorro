using EuCorro.Data.Repository;
using EuCorro.Security.Configuration;
using EuCorro.Security.Context;
using EuCorro.Security.Models;
using SimpleInjector;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Services;
using EuCorro.App;
using EuCorro.App.Interface;

namespace EuCorro.CrossCuting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

            //Infrastrutura Repositorio
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            //container.Register(typeof(IUsuarioRepository), typeof(UsuarioRepository), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeCategoriaRepository), typeof(ModalidadeCategoriaRepository), Lifestyle.Scoped);
            container.Register(typeof(IEventosRepository), typeof(EventosRepository), Lifestyle.Scoped);
            container.Register(typeof(IInscricoesRepository), typeof(InscricoesRepository), Lifestyle.Scoped);
            container.Register(typeof(IEstadosRepository), typeof(EstadosRepository), Lifestyle.Scoped);
            container.Register(typeof(ICidadesRepository), typeof(CidadesRepository), Lifestyle.Scoped);
            container.Register(typeof(IDependentesRepository), typeof(DependentesRepository), Lifestyle.Scoped);
            container.Register(typeof(IModalidadesRepository), typeof(ModalidadesRepository), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeEventoRepository), typeof(ModalidadeEventoRepository), Lifestyle.Scoped);
            container.Register(typeof(IModalidadePrecoRepository), typeof(ModalidadePrecoRepository), Lifestyle.Scoped);
            container.Register(typeof(ITipoEventoRepository), typeof(TipoEventoRepository), Lifestyle.Scoped);
            container.Register(typeof(IEmpresaRepository), typeof(EmpresaRepository), Lifestyle.Scoped);

            //Serviços de Dominio
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register(typeof(IUsuarioService), typeof(UsuarioService), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeCategoriaService), typeof(ModalidadeCategoriaService), Lifestyle.Scoped);
            container.Register(typeof(IEventosService), typeof(EventosService), Lifestyle.Scoped);
            container.Register(typeof(IInscricoesService), typeof(InscricoesService), Lifestyle.Scoped);
            container.Register(typeof(IEstadosService), typeof(EstadosService), Lifestyle.Scoped);
            container.Register(typeof(IDependenteService), typeof(DependenteService), Lifestyle.Scoped);
            container.Register(typeof(ICidadesService), typeof(CidadesService), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeService), typeof(ModalidadeService), Lifestyle.Scoped);
            container.Register(typeof(ITipoEventoService), typeof(TipoEventoService), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeEventoService), typeof(ModalidadeEventoService), Lifestyle.Scoped);
            container.Register(typeof(IModalidadePrecoService), typeof(ModalidadePrecoService), Lifestyle.Scoped);
            container.Register(typeof(IEmpresaService), typeof(EmpresaService), Lifestyle.Scoped);

            //Serviços de Aplicacao
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.Register(typeof(IHomeIndexApp), typeof(HomeIndexApp), Lifestyle.Scoped);
            container.Register(typeof(IUsuarioApp), typeof(UsuarioApp), Lifestyle.Scoped);
            //container.Register(typeof(IPerfilUsuarioApp), typeof(PerfilUsuarioApp), Lifestyle.Scoped);
            container.Register(typeof(IDependenteApp), typeof(DependenteApp), Lifestyle.Scoped);
            container.Register(typeof(IModalidadeApp), typeof(ModalidadeApp), Lifestyle.Scoped);
            container.Register(typeof(IEventoApp), typeof(EventoApp), Lifestyle.Scoped);
            container.Register(typeof(ITipoEventoApp), typeof(TipoEventoApp), Lifestyle.Scoped);
            container.Register(typeof(IHomeSiteApp), typeof(HomeSiteApp), Lifestyle.Scoped);
            container.Register(typeof(IEmpresaApp), typeof(EmpresaApp), Lifestyle.Scoped);
        }
    }
}
