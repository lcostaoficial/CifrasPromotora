using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface IBancoAppService : IDisposable
    {
        void Adicionar(BancoVm model);
        void Atualizar(BancoVm model);
        void Remover(BancoVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<BancoVm, bool>> expression);
        BancoVm BuscarPorId(int id);
        ICollection<BancoVm> BuscarPorExpressao(Expression<Func<BancoVm, bool>> expression);
        ICollection<BancoVm> ObterTodosPaginado(Expression<Func<BancoVm, bool>> expression, int start, int take, string orderBy);
        ICollection<BancoVm> BuscarTodos();
    }
}