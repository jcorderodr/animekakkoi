using System;

namespace AnimeKakkoi.Framework.Entities
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

    public enum EntityState
    {
        /// <summary>
        /// Stopped temporally
        /// </summary>
        Queue = 1,
        /// <summary>
        /// Actually Watching it
        /// </summary>
        Watching = 2,
        /// <summary>
        /// Completed
        /// </summary>
        Watched = 3,
        /// <summary>
        /// Want to see/read
        /// </summary>
        WantTo = 4,
        /// <summary>
        /// Taked down/Abandoned
        /// </summary>
        TakedDown = 5
    }
}
