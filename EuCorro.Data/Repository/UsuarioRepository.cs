using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace EuCorro.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario BuscarCPF(string cpf)
        {
            return _db.Usuario.FirstOrDefault(x => x.CPF.Equals(cpf));
        }

        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _db.Usuario.Where(p => p.UserName.Equals(nome));
        }

        public void DesativarLock(string id)
        {
            _db.Usuario.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }                                                 

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            return _db.Usuario.FirstOrDefault(p => p.Email.Equals(email));
        }
    }
}
