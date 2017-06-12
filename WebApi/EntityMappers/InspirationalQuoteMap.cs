using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Entities;

namespace WebApi.EntityMappers
{
    public class InspirationalQuoteMap
    {
        public InspirationalQuoteMap(EntityTypeConfiguration<InspirationalQuoteEntity> entityConfig)
        {
            entityConfig.ToTable("InspirationalQuotes");
            entityConfig.HasKey(t => t.Id);
            //entityBuilder.Property(t => t.FirstName).IsRequired();
            //entityBuilder.Property(t => t.LastName).IsRequired();
            //entityBuilder.Property(t => t.Email).IsRequired();
        }
    }
}