using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Models.Factories;
using WebApi.Repository.Interfaces;

namespace WebApi.Controllers
{
    public abstract class BaseApiController<T> : ApiController 
        where T : BaseEntity
    {
        private IRepository<T> _repository;
        private InspirationalQuoteFactory _inspirationalQuoteFactory;

        protected BaseApiController(IRepository<T> repository)
        {
            _repository = repository;
        }

        protected IRepository<T> Repository
        {
            get { return _repository; }
        }

        protected InspirationalQuoteFactory InspirationalQuoteFactory
        {
            get
            {
                if (_inspirationalQuoteFactory == null)
                {
                    _inspirationalQuoteFactory = new InspirationalQuoteFactory();
                }
                return _inspirationalQuoteFactory;
            }
        }
    }
}
