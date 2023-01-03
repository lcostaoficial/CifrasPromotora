using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IBancoRepository : IRepositoryBase<Banco>
    {
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<Banco, bool>> expression);
        Banco BuscarPorId(int id, bool ativo = true);
        ICollection<Banco> BuscarPorExpressao(Expression<Func<Banco, bool>> expression);
        ICollection<Banco> ObterTodosPaginado(Expression<Func<Banco, bool>> expression, int start, int take, string orderBy);
        ICollection<Banco> BuscarTodos(bool ativo = true);
        Banco BuscarPorCodigo(int codigoBanco, bool ativo = true);
        Banco BuscarPorDescricao(string descricao, bool ativo = true);
    }
}