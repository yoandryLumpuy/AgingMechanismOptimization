using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Entity<TKey>
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        public TKey Id { get; set; }
    }
}
