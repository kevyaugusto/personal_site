using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(long id);
        Task<int> Insert(T entity);
        Task<int> Update(T entity, params Expression<Func<T, object>>[] propertiesToUpdate);
        Task<int> Delete(T entity);
        bool Exists(long id);
        void Dispose();
    }
}