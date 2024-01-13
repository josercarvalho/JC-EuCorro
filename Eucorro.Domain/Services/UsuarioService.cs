using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using System;
using System.Collections.Generic;

namespace EuCorro.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _userService;
        //private readonly IPerfilUsuarioRepository _repositorioPerfil;


        public UsuarioService(IUsuarioRepository repository/*, IPerfilUsuarioRepository repositorioPerfil*/) : base(repository)
        {
            //_repositorioPerfil = repositorioPerfil;
            _userService = repository;
        }

        #region Cliente / Usuario

        public IEnumerable<Usuario> BuscarAtletas()
        {
            return _userService.GetAll(); //.Where(x => x.PerfilUsuarioId.Equals(3));
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            return _userService.RecuperarUsuarioPorEmail(email);
        }
                                
        public void CadastraUsuario(Usuario user)
        {
            //user.ChecarAtleta();

            try
            {
                if (user.Id.Equals(0))
                {
                    _userService.Add(user);
                }
                _userService.Update(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _userService.BuscarPorNome(nome);
        }

        public bool IsExistEmail(string email)
        {
            var query = _userService.RecuperarUsuarioPorEmail(email);

            return query != null;
        }

        public Usuario BuscarCPF(string cpf)
        {
            return _userService.BuscarCPF(cpf);
        }

        #endregion

        #region Perfil

        //public List<Usuario> RecuperaUsuariosDoPerfil(int perfil)
        //{
        //    return _repositorioPerfil.BuscarClientePerfil(perfil);
        //}

        //public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        //{
        //    return _repositorioPerfil.GetAll().Where(x => x.FlAtivo && !x.FlAdminMaster).ToList();
        //}                                                                           

        public void DesativarLock(string id)
        {
            _userService.DesativarLock(id);
        }

        #endregion


    }
}
