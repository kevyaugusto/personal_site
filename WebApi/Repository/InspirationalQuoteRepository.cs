using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class InspirationalQuoteRepository : Repository<InspirationalQuoteEntity>, IInspirationalQuoteRepository
    {
        public InspirationalQuoteRepository(PersonalSiteContext context) : base(context)
        {
        }
        //private readonly PersonalSiteContext _db;

        //private const string CacheKey = "InspirationalQuoteStore";

        //public IQueryable<InspirationalQuote> GetAll()
        //{
        //    return _db.InspirationalQuotes;
        //}

        //public async Task<InspirationalQuote> GetById(int id)
        //{
        //    return await _db.InspirationalQuotes.FindAsync(id);
        //}

        //public bool InspirationalQuoteExists(int id)
        //{
        //    return _db.InspirationalQuotes.Count(e => e.Id == id) > 0;
        //}


    }
}