using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<int> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("class Repository<T> error");
            }
            _entities.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult;
        }

        public async Task<int> Update(T entity, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (entity == null)
                throw new ArgumentNullException("class Repository<T> error");

            /*_entities.Attach(entity);

            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                //Get the value of the property
                var propertyValue = propertyInfo.GetValue(entity, null);

                //Assume null means that property was not passed from the client
                if (propertyValue == null)
                    continue;

                //Set this property on the entity to modified unless it is ID which will not change
                if (!propertyInfo.Name.ToLowerInvariant().Equals("id"))
                    _context.Entry(entity).Property(propertyInfo.Name).IsModified = true;
                
            }
            */

            _context.Set<T>().Attach(entity);

            foreach (var property in propertiesToUpdate)
            {
                _context.Entry(entity).Property(property).IsModified = true;
            }

            var updateResult = await _context.SaveChangesAsync();

            return updateResult;
        }

        public async Task<int> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("class Repository<T> error");
            }
            _entities.Remove(entity);

            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult;
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