using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface ITipoContratoRepository : IRepositoryBase<TipoContrato>
    {
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<TipoContrato, bool>> expression);
        TipoContrato BuscarPorId(int id, bool ativo = true);
        ICollection<TipoContrato> BuscarPorExpressao(Expression<Func<TipoContrato, bool>> expression);
        ICollection<TipoContrato> ObterTodosPaginado(Expression<Func<TipoContrato, bool>> expression, int start, int take, string orderBy);
        ICollection<TipoContrato> BuscarTodos(bool ativo = true);
        TipoContrato BuscarPorDescricao(string descricao, bool ativo = true);
    }
}