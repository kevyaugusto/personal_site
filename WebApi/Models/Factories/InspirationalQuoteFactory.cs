using System;
using WebApi.Entities;

namespace WebApi.Models.Factories
{
    public class InspirationalQuoteFactory //: IFactory
    {
        public InspirationalQuote Create(InspirationalQuoteEntity entity)
        {
            var inspirationalQuoteModel = new InspirationalQuote
            {
                Quote = entity.Quote,
                Id = entity.Id
            };

            return inspirationalQuoteModel;
        }

        //public IFactory GetFactory()
        //{
        //    return this;
        //}
    }
}
