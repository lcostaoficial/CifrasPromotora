using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        void Adicionar(ClienteVm model);
        void Atualizar(ClienteVm model);
        void Remover(ClienteVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<ClienteVm, bool>> expression);
        ClienteVm BuscarPorId(int id);
        ClienteVm BuscarPorIdBasico(int id);
        ClienteVm BuscarPorIdCustomizado(int id);
        ICollection<ClienteVm> BuscarPorExpressao(Expression<Func<ClienteVm, bool>> expression);
        ICollection<ClienteVm> ObterTodosPaginado(Expression<Func<ClienteVm, bool>> expression, int start, int take);
        ICollection<ClienteVm> ObterTodosPaginado(Expression<Func<ClienteVm, bool>> expression, int start, int take, string orderBy);
        ICollection<ClienteVm> BuscarTodos();
        bool PermitirInserir(string cpf, string matricula);
    }
}