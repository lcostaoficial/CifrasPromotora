using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ArquivoRepository : RepositoryBase<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros()
        {
            return DbSet.Count();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Arquivo, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Arquivo BuscarPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.ArquivoId == id);
        }

        public ICollection<Arquivo> BuscarPorExpressao(Expression<Func<Arquivo, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<Arquivo> ObterTodosPaginado(Expression<Func<Arquivo, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Include(x => x.CategoriaArquivo).Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Arquivo> BuscarTodos()
        {
            return DbSet.ToList();
        }
    }
}