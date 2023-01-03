using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IContaRepository : IRepositoryBase<Conta>
    {
        Conta BuscarPorId(int id);
        ICollection<Conta> BuscarTodos();
        bool VerificarExistenciaConta(int clienteId, string numeroAgencia, string numeroConta);
    }
}