using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using EuCorro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace EuCorro.App
{
    public class EmpresaApp : AppServiceBase<Empresa>, IEmpresaApp
    {
        #region Global Declearation

        private readonly IEmpresaService _empresa;
        private readonly IEstadosService _estado;
        private readonly ICidadesService _cidade;

        #endregion

        #region Constructor

        public EmpresaApp(IEmpresaService serviceBase,
                IEstadosService estados, ICidadesService cidades) : base(serviceBase)
        {
            _empresa = serviceBase;
            _estado = estados;
            _cidade = cidades;
        }

        #endregion

        #region Interface Implementation

        public IEnumerable<Cidade> BuscarPorEstado(int estado)
        {
            return _cidade.BuscarPorEstado(estado);
        }

        public IEnumerable<Estado> BuscarEstados()
        {
            return _estado.BuscaEstados();
        }

        public Empresa BuscarPorCNPJ(string CNPJ)
        {
            return _empresa.GetAll().FirstOrDefault(p=>p.CNPJ == CNPJ);
        }

        #endregion
    }
}
