using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ContratoRepository : RepositoryBase<Contrato>, IContratoRepository
    {
        public ContratoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public Contrato BuscarPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.ContratoId == id);
        }

        public Contrato BuscarPorNumero(string numeroContrato)
        {
            return DbSet.FirstOrDefault(x => x.NumeroContrato == numeroContrato);
        }

        public ICollection<Contrato> BuscarTodos()
        {
            return DbSet.ToList();
        }

        public bool VerificarExistenciaContrato(string numeroContrato)
        {
            return DbSet.Any(x => x.NumeroContrato == numeroContrato);
        }
    }
}