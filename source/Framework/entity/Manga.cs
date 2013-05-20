using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class Manga : Comic
    {

        /// <summary>
        /// Gets or sets the Manga's Category.
        /// </summary>
        new public MANGA_TYPE Category { get; set; }

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
