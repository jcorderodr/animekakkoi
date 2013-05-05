using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public  class Anime : EntitySource
    {

        public ANIME_TYPE Category { get; set; }

        public String[] Episodes { get; set; }

        /// <summary>
        /// Gets or sets an string that represent the progress in the format x/xx.
        /// </summary>
        public String EpisodesString
        {
            get
            {
                return String.Format("{0}/{1}", Episodes[0], Episodes[1]);
            }
            set
            {
                string[] temp = value.Split('/');
                Episodes = temp;
            }
        }

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
