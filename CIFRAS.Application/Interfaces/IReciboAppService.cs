using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface IReciboAppService : IDisposable
    {
        void Adicionar(ReciboVm model);
        void Atualizar(ReciboVm model);
        void Remover(ReciboVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<ReciboVm, bool>> expression);
        ReciboVm BuscarPorId(int id);
        ReciboVm BuscarPorIdCustomizado(int id);
        ICollection<ReciboVm> BuscarPorExpressao(Expression<Func<ReciboVm, bool>> expression);
        ICollection<ReciboVm> ObterTodosPaginado(Expression<Func<ReciboVm, bool>> expression, int start, int take, string orderBy);
        ICollection<ReciboVm> BuscarTodos();
    }
}