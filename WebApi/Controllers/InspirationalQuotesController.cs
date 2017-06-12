using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Models.Factories;
using WebApi.Repository;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    public class InspirationalQuotesController : BaseApiController<InspirationalQuoteEntity, InspirationalQuoteFactory>
    {
        private readonly IPersonalSiteIdentityService _identityService;

        public InspirationalQuotesController(InspirationalQuoteRepository repository, IPersonalSiteIdentityService identityService) : base(repository)
        {
            _identityService = identityService;
        }

        // GET: api/InspirationalQuotes
        public IEnumerable<InspirationalQuote> GetInspirationalQuotes()
        {
            var userName = _identityService.CurrentUser;

            var results = Repository
                .GetAll()
                .OrderBy(o => Guid.NewGuid())
                .Take(2)
                .ToList()
                .Select(s => Factory.Create(s));

            return results;
        }

        // GET: api/InspirationalQuotes/5
        [ResponseType(typeof(InspirationalQuote))]
        public async Task<IHttpActionResult> GetInspirationalQuote(int id)
        {
            var inspirationalQuote = Factory.Create(await Repository.GetById(id));

            if (inspirationalQuote == null)
            {
                return NotFound();
            }

            return Ok(inspirationalQuote);
        }

        // PUT: api/InspirationalQuotes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInspirationalQuote(int id, InspirationalQuote inspirationalQuote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != inspirationalQuote.Id)
                return BadRequest();

            var entity = Factory.Parse(inspirationalQuote);

            try
            {
                await Repository.Update(entity, p => p.AuthorId, p => p.Quote, p => p.Active, p => p.UpdatedAt);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspirationalQuoteExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/InspirationalQuotes
        [ResponseType(typeof(InspirationalQuote))]
        public async Task<IHttpActionResult> PostInspirationalQuote(InspirationalQuote inspirationalQuote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = Factory.Parse(inspirationalQuote);

            await Repository.Insert(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, Factory.Create(entity));
        }

        // DELETE: api/InspirationalQuotes/5
        [ResponseType(typeof(InspirationalQuote))]
        public async Task<IHttpActionResult> DeleteInspirationalQuote(int id)
        {
            var inspirationalQuoteEntity = await Repository.GetById(id);

            if (inspirationalQuoteEntity == null)
                return NotFound();

            var resultDelete = await Repository.Delete(inspirationalQuoteEntity);

            if (resultDelete > 0)
                return Ok(Factory.Create(inspirationalQuoteEntity));

            return InternalServerError();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Repository.Dispose();

            base.Dispose(disposing);
        }

        private bool InspirationalQuoteExists(int id)
        {
            return Repository.Exists(id);
        }
    }
}