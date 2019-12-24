using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Wyj.Core.Dtos;

namespace Wyj.Core.IRespository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
        void Update(TEntity entityToUpdate);

        void Save();
    }
}
