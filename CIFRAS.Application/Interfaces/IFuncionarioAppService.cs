using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface IFuncionarioAppService : IDisposable
    {
        void Adicionar(FuncionarioVm model);
        void Atualizar(FuncionarioVm model);
        void Remover(FuncionarioVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<FuncionarioVm, bool>> expression);
        bool ValidarLogin(string login, string senha);
        FuncionarioVm UsuarioLogado();
        void DesconectarUsuario();
        FuncionarioVm BuscarPorId(int id);
        ICollection<FuncionarioVm> BuscarPorExpressao(Expression<Func<FuncionarioVm, bool>> expression);
        ICollection<FuncionarioVm> ObterTodosPaginado(Expression<Func<FuncionarioVm, bool>> expression, int start, int take, string orderBy);
        ICollection<FuncionarioVm> BuscarTodos();
    }
}