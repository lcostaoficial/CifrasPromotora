using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IReciboEmprestimoService : IDisposable
    {
        void Adicionar(ReciboEmprestimo model);
        void Atualizar(ReciboEmprestimo model);
        void Remover(ReciboEmprestimo model);
        ReciboEmprestimo BuscarPorId(int id);
        ICollection<ReciboEmprestimo> BuscarTodos();
    }
}