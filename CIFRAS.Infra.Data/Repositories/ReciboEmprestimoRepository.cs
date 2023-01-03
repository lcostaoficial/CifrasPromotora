using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ReciboEmprestimoRepository : RepositoryBase<ReciboEmprestimo>, IReciboEmprestimoRepository
    {
        public ReciboEmprestimoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public ReciboEmprestimo BuscarPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.ReciboEmprestimoId == id);
        }

        public ICollection<ReciboEmprestimo> BuscarTodos()
        {
            return DbSet.ToList();
        }
    }
}