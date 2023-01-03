using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace CIFRAS.Infra.Data.Repositories
{
    public class CategoriaArquivoRepository : RepositoryBase<CategoriaArquivo>, ICategoriaArquivoRepository
    {
        public CategoriaArquivoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public CategoriaArquivo BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.CategoriaArquivoId == id && x.Ativo == ativo);
        }

        public ICollection<CategoriaArquivo> BuscarPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<CategoriaArquivo> ObterTodosPaginado(Expression<Func<CategoriaArquivo, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<CategoriaArquivo> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }
    }
}