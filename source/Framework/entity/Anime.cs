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

        public override void FromString(string text)
        {
            base.FromString(text);

            int init = 0;

            init = text.LastIndexOf('@') + 1;
            this.Category = (Framework.entity.ANIME_TYPE)Enum.Parse(typeof(Framework.entity.ANIME_TYPE), text.Substring(init));
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
