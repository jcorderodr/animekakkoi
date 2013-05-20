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
            return String.Format("{0} @ {3}, [Rat:{2} / {1}]", Name, State, Rating, Category);
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
