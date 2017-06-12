using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Models.Factories;
using WebApi.Repository;
using WebApi.Repository.Interfaces;

namespace WebApi.Controllers
{
    public class InspirationalQuotesController : BaseApiController<InspirationalQuoteEntity>
    {
        private readonly InspirationalQuoteFactory _inspirationalQuoteFactory;

        public InspirationalQuotesController(InspirationalQuoteRepository repository) : base(repository)
        {
            _inspirationalQuoteFactory = new InspirationalQuoteFactory();
        }

        // GET: api/InspirationalQuotes
        public IEnumerable<InspirationalQuote> GetInspirationalQuotes()
        {
            var inspirationalQuoteEntities = Repository.GetAll()
                .OrderBy(o => Guid.NewGuid())
                .Take(2)
                .ToList();
            var results = inspirationalQuoteEntities
                            .Select(s => _inspirationalQuoteFactory.Create(s));

            return results;
        }

        // GET: api/InspirationalQuotes/5
        [ResponseType(typeof(InspirationalQuote))]
        public async Task<IHttpActionResult> GetInspirationalQuote(int id)
        {
            var inspirationalQuote = _inspirationalQuoteFactory.Create(await Repository.GetById(id));

            if (inspirationalQuote == null)
            {
                return NotFound();
            }

            return Ok(inspirationalQuote);
        }

        // PUT: api/InspirationalQuotes/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutInspirationalQuote(int id, InspirationalQuote inspirationalQuote)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != inspirationalQuote.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _db.Entry(inspirationalQuote).State = EntityState.Modified;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InspirationalQuoteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/InspirationalQuotes
        //[ResponseType(typeof(InspirationalQuote))]
        //public async Task<IHttpActionResult> PostInspirationalQuote(InspirationalQuote inspirationalQuote)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.InspirationalQuotes.Add(inspirationalQuote);
        //    await _db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = inspirationalQuote.Id }, inspirationalQuote);
        //}

        //// DELETE: api/InspirationalQuotes/5
        //[ResponseType(typeof(InspirationalQuote))]
        //public async Task<IHttpActionResult> DeleteInspirationalQuote(int id)
        //{
        //    InspirationalQuote inspirationalQuote = await _db.InspirationalQuotes.FindAsync(id);
        //    if (inspirationalQuote == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.InspirationalQuotes.Remove(inspirationalQuote);
        //    await _db.SaveChangesAsync();

        //    return Ok(inspirationalQuote);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InspirationalQuoteExists(int id)
        {
            return Repository.Exists(id);
        }
    }
}