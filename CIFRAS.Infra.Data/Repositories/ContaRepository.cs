using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ContaRepository : RepositoryBase<Conta> , IContaRepository
    {
        public ContaRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public Conta BuscarPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.ContaId == id);
        }

        public ICollection<Conta> BuscarTodos()
        {
            return DbSet.ToList();
        }

        public bool VerificarExistenciaConta(int clienteId, string numeroAgencia, string numeroConta)
        {
            return DbSet.Any(x => x.NumeroAgencia ==  numeroAgencia && x.NumeroConta == numeroConta && x.ClienteId == clienteId);
        }
    }
}