using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IReciboEmprestimoRepository : IRepositoryBase<ReciboEmprestimo>
    {
        ReciboEmprestimo BuscarPorId(int id);
        ICollection<ReciboEmprestimo> BuscarTodos();
    }
}