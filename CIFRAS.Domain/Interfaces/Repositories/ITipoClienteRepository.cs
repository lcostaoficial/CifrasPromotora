using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface ITipoClienteRepository : IRepositoryBase<TipoCliente>
    {
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<TipoCliente, bool>> expression);
        TipoCliente BuscarPorId(int id, bool ativo = true);
        ICollection<TipoCliente> BuscarPorExpressao(Expression<Func<TipoCliente, bool>> expression);       
        ICollection<TipoCliente> ObterTodosPaginado(Expression<Func<TipoCliente, bool>> expression, int start, int take, string orderBy);
        ICollection<TipoCliente> BuscarTodos(bool ativo = true);
        TipoCliente BuscarPorDescricao(string descricao, bool ativo = true);
    }
}