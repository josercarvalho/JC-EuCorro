using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using System.Collections.Generic;

namespace EuCorro.App
{
    public class ModalidadeApp : AppServiceBase<Modalidade>, IModalidadeApp
    {
        private readonly IModalidadeService _servModalidade;
        public ModalidadeApp(IModalidadeService serviceBase) : base(serviceBase)
        {
            _servModalidade = serviceBase;
        }

        public IEnumerable<Modalidade> GetByName(string name)
        {
            return _servModalidade.GetByName(name);
        }
    }
}
