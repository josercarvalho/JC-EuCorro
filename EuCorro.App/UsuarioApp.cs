using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using EuCorro.Security.Configuration;
using System.Collections.Generic;
using System.Security.Claims;

namespace EuCorro.App
{
    public class UsuarioApp : AppServiceBase<Usuario>, IUsuarioApp
    {
        #region Global Declearation

        private readonly IUsuarioService _usuario;
        //private readonly IPerfilUsuarioService _perfilUsuario;
        private readonly IInscricoesService _inscricoes;
        private readonly IEstadosService _estado;
        private readonly ICidadesService _cidade;
        private readonly ApplicationUserManager _userManager;

        #endregion

        #region Construtor

        public UsuarioApp(IUsuarioService repositoryUsuario,
            ApplicationUserManager userManager,
            IInscricoesService inscritos,
            IEstadosService estados, ICidadesService cidades) : base(repositoryUsuario)
        {
            _usuario = repositoryUsuario;
            _userManager = userManager;
            _inscricoes = inscritos;
            _estado = estados;
            _cidade = cidades;
        }

        #endregion

        #region Login Usuário

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            return _usuario.RecuperarUsuarioPorEmail(email);
        }
                                       
        #endregion

        #region Cadastro de Usuário e Atletas

        public void CadastraUsuario(Usuario user)
        {
            _usuario.CadastraUsuario(user);
            _userManager.AddClaimAsync(user.Id, new Claim("Operador", "True"));
        }

        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _usuario.BuscarPorNome(nome);
        }

        public bool IsExistEmail(string email)
        {
            return _usuario.IsExistEmail(email);
        }

        public Usuario BuscarCPF(string cpf)
        {
            return _usuario.BuscarCPF(cpf);
        }

        public IEnumerable<Cidade> BuscarPorEstado(int estado)
        {
            return _cidade.BuscarPorEstado(estado);
        }

        public IEnumerable<Estado> BuscarEstados()
        {
            return _estado.BuscaEstados();
        }

        public IEnumerable<Usuario> BuscarAtletas()
        {
            return _usuario.BuscarAtletas();
        }
        #endregion

        #region Perfil do Usuário

        //public List<Usuario> RecuperaUsuariosDoPerfil(int perfil)
        //{
        //    return _usuario.RecuperaUsuariosDoPerfil(perfil);
        //}

        //public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        //{
        //    return _usuario.RecuperaTodosPerfisAtivos();
        //}




        #endregion
    }
}
