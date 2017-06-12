using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Repository.Interfaces
{
    public interface IInspirationalQuoteRepository : IRepository<InspirationalQuoteEntity>
    {
        //IQueryable<InspirationalQuote> GetAll();
        //Task<InspirationalQuote> GetById(int id);
        //bool InspirationalQuoteExists(int id);
        //void Dispose();
    }
}
