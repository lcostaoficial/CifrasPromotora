using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public Contato BuscarPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.ContatoId == id);
        }

        public ICollection<Contato> BuscarTodos()
        {
            return DbSet.ToList();
        }

        public bool VerificarExistenciaContato(string descricao)
        {
            return DbSet.Any(x => x.Descricao == descricao);
        }
    }
}