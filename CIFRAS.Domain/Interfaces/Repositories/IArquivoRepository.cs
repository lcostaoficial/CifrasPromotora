using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface IArquivoRepository : IRepositoryBase<Arquivo>
    {
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<Arquivo, bool>> expression);
        Arquivo BuscarPorId(int id);
        ICollection<Arquivo> BuscarPorExpressao(Expression<Func<Arquivo, bool>> expression);
        ICollection<Arquivo> ObterTodosPaginado(Expression<Func<Arquivo, bool>> expression, int start, int take, string orderBy);
        ICollection<Arquivo> BuscarTodos();
    }
}