﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zervo.Data.Infrastructure;

namespace Zervo.Data.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll();
        int Count();
        TEntity GetSingle(int id);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        IQueryable<TEntity> Queryable();
    }
}