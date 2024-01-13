using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IEmpresaApp : IAppServiceBase<Empresa>
    {
        IEnumerable<Estado> BuscarEstados();
        IEnumerable<Cidade> BuscarPorEstado(int estado);
        Empresa BuscarPorCNPJ(string CNPJ);
    }
}
