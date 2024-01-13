using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IModalidadeService : IServiceBase<Modalidade>
    {
        IEnumerable<Modalidade> GetByName(string name);
    }
}
