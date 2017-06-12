using System;
using System.Net.Http;
using System.Web.Http.Routing;
using WebApi.Entities;

namespace WebApi.Models.Factories
{
    public class InspirationalQuoteFactory : IFactory
    {
        public InspirationalQuote Create(InspirationalQuoteEntity entity)
        {
            var inspirationalQuoteModel = new InspirationalQuote
            {
                Id = entity.Id,
                Quote = entity.Quote,
                AuthorId = entity.AuthorId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Active = entity.Active
            };

            return inspirationalQuoteModel;
        }

        public InspirationalQuoteEntity Parse(InspirationalQuote model)
        {
            var inspirationalQuoteEntity = new InspirationalQuoteEntity
            {
                Id = model.Id,
                Quote = model.Quote,
                AuthorId = model.AuthorId,
                Active = model.Active,
                UpdatedAt = model.UpdatedAt
            };

            return inspirationalQuoteEntity;
        }

        public HttpRequestMessage Request { get; set; }
        public UrlHelper UrlHelper { get; set; }
    }
}