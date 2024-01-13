using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IPerfilUsuarioRepository : IRepositoryBase<PerfilUsuario>
    {
        List<Usuario> BuscarClientePerfil(int perfilCliente);
    }
}
