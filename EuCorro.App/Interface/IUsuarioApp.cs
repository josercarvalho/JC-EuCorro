using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IUsuarioApp : IAppServiceBase<Usuario>
    {
        #region Login do Usuario

        Usuario RecuperarUsuarioPorEmail(string email);

        #endregion

        #region Cadastro de Atletas e usuário

        IEnumerable<Estado> BuscarEstados();
        Usuario BuscarCPF(string cpf);
        void CadastraUsuario(Usuario user);
        bool IsExistEmail(string email);
        IEnumerable<Cidade> BuscarPorEstado(int estado);
        IEnumerable<Usuario> BuscarPorNome(string nome);
        IEnumerable<Usuario> BuscarAtletas();

        #endregion

        #region Perfil do Usuario

        //List<Usuario> RecuperaUsuariosDoPerfil(int perfil);
        //List<PerfilUsuario> RecuperaTodosPerfisAtivos();

        #endregion
    }
}
