using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class Entity 
    {
        public int Codigo { get; set; }

        public String Name { get; set; }

        /// <summary>
        /// Gets or sets an string that represent the progress in the format x/xx.
        /// </summary>
        public virtual String ProgressString { get; set; }

    }
}
