using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IModalidadeApp : IAppServiceBase<Modalidade>
    {
        IEnumerable<Modalidade> GetByName(string name);
    }
}
