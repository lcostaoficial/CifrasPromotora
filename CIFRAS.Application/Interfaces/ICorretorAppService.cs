using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface ICorretorAppService : IDisposable
    {
        void Adicionar(CorretorVm model);
        void Atualizar(CorretorVm model);
        void Remover(CorretorVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<CorretorVm, bool>> expression);
        CorretorVm BuscarPorId(int id);
        ICollection<CorretorVm> BuscarPorExpressao(Expression<Func<CorretorVm, bool>> expression);
        ICollection<CorretorVm> ObterTodosPaginado(Expression<Func<CorretorVm, bool>> expression, int start, int take, string orderBy);
        ICollection<CorretorVm> BuscarTodos();
    }
}