using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class Anime : EntitySource
    {

        public ANIME_TYPE Category { get; set; }

        public override string ToString()
        {
            return base.ToString() + " @ " + Category;
        }

    }

    public enum ANIME_TYPE
    {
        SERIE = 1,
        OVA = 2,
        MOVIE = 3,
        SPECIAL = 4,
        WEB = 5
    }



}
