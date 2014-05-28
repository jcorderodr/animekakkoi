using System;

namespace AnimeKakkoi.Core.Entities
{
    public sealed class Anime : EntitySource
    {

        public AnimeType Category { get; set; }

        public override string ToString()
        {
            return base.ToString() + " @ " + Category;
        }

        public override void FromString(string text)
        {
            base.FromString(text);

            var init = 0;

            init = text.LastIndexOf('@') + 1;
            this.Category = (AnimeType)Enum.Parse(typeof(AnimeType), text.Substring(init));
        }

    }

    public enum AnimeType
    {
        Serie = 1,
        Ova = 2,
        Movie = 3,
        Special = 4,
        Web = 5
    }



}
