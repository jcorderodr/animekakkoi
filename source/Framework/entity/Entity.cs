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

    public abstract class EntityProperties
    {

        public const String ENTITY_FAVORITE_MARK = "<3";

        public const Char EPISODE_CHAPTER_SEPARATOR = '/';

        public const Char EPISODE_CHAPTER_EMPTYCHAR = '-';

        public const Int32 EPISODE_CHAPTER_EMPTYINT = 0;

    }

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
