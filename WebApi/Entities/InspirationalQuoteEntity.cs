using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    
    public class InspirationalQuoteEntity : BaseEntity
    {
        public string Quote { get; set; }

        /// <summary>
        /// ForeignKey 
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual AuthorEntity Author { get; set; }
    }
}
