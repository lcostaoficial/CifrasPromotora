using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Endereco BuscarPorId(int id);
        ICollection<Endereco> BuscarTodos();
    }
}