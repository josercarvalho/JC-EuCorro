using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface ICadastroAtletaApp
    {
        IEnumerable<Estado> BuscarEstados();
        Usuario BuscarCPF(string cpf);
        void CadastraUsuario(Usuario user);
        bool IsExistEmail(string email);
        IEnumerable<Cidade> BuscarPorEstado(int estado);
    }
}
