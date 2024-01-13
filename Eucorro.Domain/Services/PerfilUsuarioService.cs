using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Services
{
    public class PerfilUsuarioService : ServiceBase<PerfilUsuario>, IPerfilUsuarioService
    {
        private readonly IPerfilUsuarioRepository _repositorioDePerfilDeUsuario;
        public PerfilUsuarioService(IPerfilUsuarioRepository repositorioDePerfilDeUsuario)
            : base(repositorioDePerfilDeUsuario)
        {
            _repositorioDePerfilDeUsuario = repositorioDePerfilDeUsuario;
        }

        public List<Usuario> BuscarClientePerfil(int perfilCliente)
        {
            return _repositorioDePerfilDeUsuario.BuscarClientePerfil(perfilCliente);
        }
    }
}
