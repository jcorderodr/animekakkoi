using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{

    public enum ENTITY_STATE
    {
        /// <summary>
        /// Stopped temporally
        /// </summary>
        QUEUE = 1,
        /// <summary>
        /// Actually Watching it
        /// </summary>
        WATCHING = 2,
        /// <summary>
        /// Completed
        /// </summary>
        WATCHED = 3,
        /// <summary>
        /// Want to see/read
        /// </summary>
        WANT_TO = 4,
        /// <summary>
        /// Taked down/Abandoned
        /// </summary>
        TAKED_DOWN = 5
    }

}
