using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class InspirationalQuote : BaseModel
    {
        public string Quote { get; set; }

        /// <summary>
        /// ForeignKey 
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Author Author { get; set; }
    }
}