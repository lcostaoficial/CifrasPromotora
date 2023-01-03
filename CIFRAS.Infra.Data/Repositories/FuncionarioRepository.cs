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
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    { 
        public FuncionarioRepository(CifrasContext cifrasContext) : base (cifrasContext) { }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Funcionario, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Funcionario ValidarLogin(string login, string senha)
        {
            return DbSet.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.Ativo);
        }

        public Funcionario BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.FuncionarioId == id && x.Ativo == ativo);
        }

        public ICollection<Funcionario> BuscarPorExpressao(Expression<Func<Funcionario, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<Funcionario> ObterTodosPaginado(Expression<Func<Funcionario, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Funcionario> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }
    }
}