using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IContratoRepository : IRepositoryBase<Contrato>
    {
        Contrato BuscarPorId(int id);
        Contrato BuscarPorNumero(string numeroContrato);
        ICollection<Contrato> BuscarTodos();
        bool VerificarExistenciaContrato(string numeroContrato);
    }
}