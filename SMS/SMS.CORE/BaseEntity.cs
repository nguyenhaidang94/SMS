using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.CORE
{
    /// <summary>
    /// base entity
    /// </summary>
    public partial class BaseEntity
    {
        /// <summary>
        /// when entity is deleded, set Active = false
        /// </summary>
        public virtual bool Active { get; set; }

        public BaseEntity()
        { }
    }
}
