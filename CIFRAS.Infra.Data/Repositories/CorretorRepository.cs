using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace CIFRAS.Infra.Data.Repositories
{
    public class CorretorRepository : RepositoryBase<Corretor>, ICorretorRepository
    {
        public CorretorRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Corretor, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Corretor BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.CorretorId == id && x.Ativo == ativo);
        }

        public ICollection<Corretor> BuscarPorExpressao(Expression<Func<Corretor, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }     

        public ICollection<Corretor> ObterTodosPaginado(Expression<Func<Corretor, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Corretor> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }
    }
}