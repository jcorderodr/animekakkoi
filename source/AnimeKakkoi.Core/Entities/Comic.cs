using System;

namespace AnimeKakkoi.Core.Entities
{
    public class Comic : EntitySource
    {

        public ComicType Category { get; set; }

        /// <summary>
        /// Gets or sets the values that represents the progress.
        /// </summary>
        public String[] Chapters
        {
            get { return Episodes; } 
            set { Episodes = value; }
        }
        
    }


    public enum ComicType
    {
        Comic = 1,
        GraphicNovel = 3
    }

}
