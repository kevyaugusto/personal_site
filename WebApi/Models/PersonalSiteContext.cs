using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Entities;
using WebApi.EntityMappers;

namespace WebApi.Models
{
    public class PersonalSiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public PersonalSiteContext() : base("name=PersonalSiteContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new InspirationalQuoteMap(modelBuilder.Entity<InspirationalQuoteEntity>());
            //new BookMap(modelBuilder.Entity<Book>());
        }

        public System.Data.Entity.DbSet<WebApi.Entities.InspirationalQuoteEntity> InspirationalQuotes { get; set; }
        public System.Data.Entity.DbSet<WebApi.Entities.AuthorEntity> Authors { get; set; }
    }
}
