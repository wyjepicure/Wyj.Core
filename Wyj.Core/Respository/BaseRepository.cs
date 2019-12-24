using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wyj.Core.Data;
using Wyj.Core.Dtos;
using Wyj.Core.IRespository;
using Wyj.Core.Models;

namespace Wyj.Core.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected MyDbContext Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(MyDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }
      

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
        {
            var source = DbSet.Where(whereExpression);
            int count = await source.CountAsync();
            List<TEntity> entitiesntitys = null;
            int pageCount = (count / intPageSize);
            if (count > 0)
            {
                entitiesntitys = await source.Skip((intPageIndex - 1) * intPageSize).Take(intPageSize).ToListAsync();
            }
            return new PageModel<TEntity>() { dataCount = count, pageCount = pageCount, page = intPageIndex, PageSize = intPageSize, data = entitiesntitys };
        }
    }
}
