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
    public class TipoClienteRepository : RepositoryBase<TipoCliente> , ITipoClienteRepository
    {
        public TipoClienteRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoCliente, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public TipoCliente BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.TipoClienteId == id && x.Ativo == ativo);
        }  
        
        public ICollection<TipoCliente> BuscarPorExpressao(Expression<Func<TipoCliente, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<TipoCliente> ObterTodosPaginado(Expression<Func<TipoCliente, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<TipoCliente> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }

        public TipoCliente BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => (x.Descricao.ToLower().Contains(descricao.ToLower()) || descricao.ToLower().Contains(x.Descricao.ToLower())) && x.Ativo == ativo);
        }
    }
}