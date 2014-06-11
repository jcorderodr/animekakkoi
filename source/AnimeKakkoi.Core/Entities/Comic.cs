using System;

namespace AnimeKakkoi.Core.Entities
{
    public class Comic : EntitySource
    {

        public ComicType Category { get; set; }

       
        
    }


    public enum ComicType
    {
        Comic = 1,
        GraphicNovel = 3
    }

}
