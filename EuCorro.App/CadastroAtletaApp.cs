using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using System.Collections.Generic;

namespace EuCorro.App
{
    public class CadastroAtletaApp : ICadastroAtletaApp
    {
        private readonly IEstadosService _estado;
        private readonly ICidadesService _cidade;
        private readonly IUsuarioApp _user;


        public CadastroAtletaApp(IUsuarioApp user, IEstadosService estados, ICidadesService cidades)
        {
            _user = user;
            _estado = estados;
            _cidade = cidades;
        }

        public Usuario BuscarCPF(string cpf)
        {
            return _user.BuscarCPF(cpf);
        }

        public IEnumerable<Estado> BuscarEstados()
        {
            return _estado.BuscaEstados();
        }

        public void CadastraUsuario(Usuario user)
        {
            _user.CadastraUsuario(user);
        }

        public bool IsExistEmail(string email)
        {
            return _user.IsExistEmail(email);
        }

        public IEnumerable<Cidade> BuscarPorEstado(int estado)
        {
            return _cidade.BuscarPorEstado(estado);
        }
    }
}
