using System;

namespace AnimeKakkoi.Framework.Entities
{
    public class Comic : EntitySource
    {

        public COMIC_TYPE Category { get; set; }

        /// <summary>
        /// Gets or sets the values that represents the progress.
        /// </summary>
        public String[] Chapters { get { return Episodes; } set { Episodes = value; } }

     
        
    }


    public enum COMIC_TYPE
    {
        COMIC = 1,
        GRAPHIC_NOVEL = 3
    }

}
