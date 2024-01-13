using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        #region Cliente / Usuario

        void DesativarLock(string id);
        Usuario RecuperarUsuarioPorEmail(string email);
        void CadastraUsuario(Usuario user);
        IEnumerable<Usuario> BuscarPorNome(string nome);
        bool IsExistEmail(string email);
        Usuario BuscarCPF(string cpf);
        IEnumerable<Usuario> BuscarAtletas();

        #endregion

        #region PerfilUsuario

        //List<Usuario> RecuperaUsuariosDoPerfil(int perfil);
        //List<PerfilUsuario> RecuperaTodosPerfisAtivos();

        #endregion

    }
}
