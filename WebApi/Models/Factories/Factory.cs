using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Entities;

namespace WebApi.Models.Factories
{
    public interface IFactory
    {
        HttpRequestMessage Request { get; set; }

        UrlHelper UrlHelper { get; set; }
    }
}
