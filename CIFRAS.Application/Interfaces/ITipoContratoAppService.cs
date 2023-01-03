using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface ITipoContratoAppService : IDisposable
    {
        void Adicionar(TipoContratoVm model);
        void Atualizar(TipoContratoVm model);
        void Remover(TipoContratoVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<TipoContratoVm, bool>> expression);
        TipoContratoVm BuscarPorId(int id);
        ICollection<TipoContratoVm> BuscarPorExpressao(Expression<Func<TipoContratoVm, bool>> expression);
        ICollection<TipoContratoVm> ObterTodosPaginado(Expression<Func<TipoContratoVm, bool>> expression, int start, int take, string orderBy);
        ICollection<TipoContratoVm> BuscarTodos();
    }
}