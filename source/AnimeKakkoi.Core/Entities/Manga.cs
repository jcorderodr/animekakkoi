namespace AnimeKakkoi.Core.Entities
{
    public sealed class Manga : Comic
    {

        /// <summary>
        /// Gets or sets the Manga's Category.
        /// </summary>
        new public MangaType Category { get; set; }

    }

    /// <summary>
    /// Indicate the type / kind of the manga.
    /// </summary>
    public enum MangaType
    {
        Manga = 1,
        Manhwa = 2,
        Novel = 3,
        OneShot = 4
    }

}
