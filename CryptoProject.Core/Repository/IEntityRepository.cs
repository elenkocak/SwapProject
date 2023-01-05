using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Core.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        IList<T> GetList(Expression<Func<T, bool>> filteR = null);
        T GetLast(Expression<Func<T, bool>> filter = null, Expression<Func<T, int>> orderby = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
