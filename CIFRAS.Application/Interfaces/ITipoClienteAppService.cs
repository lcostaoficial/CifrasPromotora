using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface ITipoClienteAppService : IDisposable
    {
        void Adicionar(TipoClienteVm model);
        void Atualizar(TipoClienteVm model);
        void Remover(TipoClienteVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<TipoClienteVm, bool>> expression);
        TipoClienteVm BuscarPorId(int id);
        ICollection<TipoClienteVm> BuscarPorExpressao(Expression<Func<TipoClienteVm, bool>> expression);       
        ICollection<TipoClienteVm> ObterTodosPaginado(Expression<Func<TipoClienteVm, bool>> expression, int start, int take, string orderBy);
        ICollection<TipoClienteVm> BuscarTodos();
    }
}