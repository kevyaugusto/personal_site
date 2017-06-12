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
    public abstract class BaseApiController<T, T1> : ApiController 
        where T : BaseEntity
        where T1 : IFactory, new()
    {
        private IRepository<T> _repository;
        private T1 _factory;

        protected BaseApiController(IRepository<T> repository)
        {
            _repository = repository;
        }

        protected IRepository<T> Repository
        {
            get { return _repository; }
        }

        protected T1 Factory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new T1();
                    _factory.Request = this.Request;
                }
                return _factory;
            }
        }
    }
}
