using System.Collections.Generic;
using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Models;
using System.Linq;
using System.Data.Entity;

namespace EuCorro.Data.Repository
{
    public class ModalidadeEventoRepository : RepositoryBase<ModalidadeEvento>, IModalidadeEventoRepository
    {
        public IEnumerable<ModalidadeEvento> ListarModalidade()
        {
            return _db.ModalidadeEventos.ToList();
        }

        public IEnumerable<ModalidadeEvento> ListarModalidadePorEvento(int evento)
        {
            return _db.ModalidadeEventos.Include(p => p.Modalidade).Include(p => p.ModalidadeCategorias).Include(p => p.Inscricoes).Where(p => p.EventoId.Equals(evento)).ToList();
        }

        public void RemoveEvento(int evento)
        {
            _db.ModalidadeEventos.RemoveRange(_db.ModalidadeEventos.Where(p => p.EventoId.Equals(evento)));
        }
    }
}
