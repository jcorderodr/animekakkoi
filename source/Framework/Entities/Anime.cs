using System;

namespace AnimeKakkoi.Framework.Entities
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
            this.Category = (global::AnimeKakkoi.Framework.Entities.ANIME_TYPE)Enum.Parse(typeof(global::AnimeKakkoi.Framework.Entities.ANIME_TYPE), text.Substring(init));
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
