using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Repositories
{
    public interface ICategoriaArquivoRepository : IRepositoryBase<CategoriaArquivo>
    {
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression);
        CategoriaArquivo BuscarPorId(int id, bool ativo = true);
        ICollection<CategoriaArquivo> BuscarPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression);
        ICollection<CategoriaArquivo> ObterTodosPaginado(Expression<Func<CategoriaArquivo, bool>> expression, int start, int take, string orderBy);
        ICollection<CategoriaArquivo> BuscarTodos(bool ativo = true);
    }
}