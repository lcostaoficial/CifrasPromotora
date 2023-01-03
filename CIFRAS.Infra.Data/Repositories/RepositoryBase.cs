using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System;
using System.Data.Entity;

namespace CIFRAS.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CifrasContext Context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(CifrasContext cifrasContext)
        {
            Context = cifrasContext;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public virtual TEntity Remover(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Context.Dispose();
        }
    }
}