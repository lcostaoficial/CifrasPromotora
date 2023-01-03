using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Contato BuscarPorId(int id);
        ICollection<Contato> BuscarTodos();
        bool VerificarExistenciaContato(string descricao);
    }
}