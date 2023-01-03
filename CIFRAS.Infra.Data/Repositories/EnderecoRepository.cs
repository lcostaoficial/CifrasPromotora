using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CIFRAS.Infra.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco> , IEnderecoRepository
    {
        public EnderecoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public Endereco BuscarPorId (int id)
        {
            return DbSet.FirstOrDefault(x => x.EnderecoId == id);
        }

        public ICollection<Endereco> BuscarTodos()
        {
            return DbSet.ToList();
        }
    }
}