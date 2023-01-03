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
    public class BancoRepository : RepositoryBase<Banco>, IBancoRepository
    {
        public BancoRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Banco, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Banco BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.BancoId == id && x.Ativo == ativo);
        }

        public ICollection<Banco> BuscarPorExpressao(Expression<Func<Banco, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<Banco> ObterTodosPaginado(Expression<Func<Banco, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Banco> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }

        public Banco BuscarPorCodigo(int codigoBanco, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.CodigoBanco == codigoBanco && x.Ativo == ativo);
        }

        public Banco BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => (x.Descricao.ToLower().Contains(descricao.ToLower()) || descricao.ToLower().Contains(x.Descricao.ToLower()) || x.Sigla.ToLower().Contains(descricao.ToLower()) || descricao.ToLower().Contains(x.Sigla.ToLower())) && x.Ativo == ativo);
        }
    }
}