using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PersonalSiteContext _context;
        private readonly DbSet<T> _entities;

        public Repository(PersonalSiteContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public async Task<T> GetById(long id)
        {
            return await _entities.FindAsync(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("class Repository<T> error");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("class Repository<T> error");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("class Repository<T> error");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _entities.Count(f => f.Id == id) > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}