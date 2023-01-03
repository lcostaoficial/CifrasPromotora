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
    public class TipoContratoRepository : RepositoryBase<TipoContrato> , ITipoContratoRepository
    {
        public TipoContratoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoContrato, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public ICollection<TipoContrato> BuscarPorExpressao(Expression<Func<TipoContrato, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<TipoContrato> ObterTodosPaginado(Expression<Func<TipoContrato, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public TipoContrato BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.TipoContratoId == id && x.Ativo == ativo);
        }      

        public ICollection<TipoContrato> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }

        public TipoContrato BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.Descricao.ToLower().Contains(descricao.ToLower()) && x.Ativo == ativo);
        }
    }
}