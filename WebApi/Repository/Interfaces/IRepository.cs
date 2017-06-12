using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(long id);
        void Dispose();
    }
}