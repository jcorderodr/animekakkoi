using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class Manga : EntitySource
    {

        /// <summary>
        /// Gets or sets the Manga's Category.
        /// </summary>
        public MANGA_TYPE Category { get; set; }

        /// <summary>
        /// Gets or sets the values that represents the progress.
        /// </summary>
        public String[] Chapters { get; set; }

        /// <summary>
        /// Gets or sets an string that represent the progress in the format x/xx.
        /// </summary>
        public string ChapterString
        {
            get
            {
                return String.Format("{0}/{1}", Chapters[0], Chapters[1]);
            }
            set
            {
                string[] temp = value.Split('/');

                Chapters = temp;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} @ {3}, ~ {4}/{5} ~ [Rat:{2} / {1}]", Name, State, Rating, Category, Chapters[0], Chapters[1]);
        }

    }

    /// <summary>
    /// Indicate the type / kind of the manga.
    /// </summary>
    public enum MANGA_TYPE
    {
        MANGA = 1,
        MANHWA = 2
    }

}
