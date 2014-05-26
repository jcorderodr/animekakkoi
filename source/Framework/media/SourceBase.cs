using System.Collections.Generic;
using AnimeKakkoi.Framework.Entities;

namespace AnimeKakkoi.Framework.media
{
    public abstract class SourceBase
    {

        public readonly Dictionary<string, MANGA_TYPE> MangaTypeCategories;

        public readonly Dictionary<string, ANIME_TYPE> AnimeTypesCategories;

        public readonly Dictionary<string, EntityState> StateCategories;

        public List<object> Items { get; set; }

        public void Dispose()
        {
            this.Items = null;
            StateCategories.Clear();
            AnimeTypesCategories.Clear();
            MangaTypeCategories.Clear();
        }

        public SourceBase()
        {

            /*
             * Categories & Labels
             * TODO: Make this configurable and not 100% programming.
             * PD: There are some reapeated labels.
             */
            StateCategories = new Dictionary<string, EntityState>();
            //
            // - McAnime
            //
            StateCategories.Add("La abandone", EntityState.TakedDown);
            StateCategories.Add("La quiero ver", EntityState.WantTo);
            StateCategories.Add("La deje de ver temporalmente", EntityState.Queue);
            StateCategories.Add("La estoy viendo", EntityState.Watching);
            StateCategories.Add("La vi completa", EntityState.Watched);
            StateCategories.Add("La quiero leer", EntityState.WantTo);
            StateCategories.Add("La estoy leyendo", EntityState.Watching);
            StateCategories.Add("La leí completa", EntityState.Watched);
            StateCategories.Add("La deje de leer temporalmente", EntityState.Queue);
            //-repeat StateCategories.Add("La abandone", ENTITY_STATE.TAKED_DOWN);
            //
            //- McAnime Kronos
            //
            StateCategories.Add("Viendo", EntityState.Watching);
            StateCategories.Add("Completadas", EntityState.Watched);
            StateCategories.Add("Pausadas/En espera", EntityState.Queue);
            StateCategories.Add("Quiere ver", EntityState.WantTo);
            StateCategories.Add("Abandonadas", EntityState.TakedDown);
            StateCategories.Add("Leyendo", EntityState.Watching);
            //-repeat StateCategories.Add("Completadas", ENTITY_STATE.WATCHED);
            //-repeat StateCategories.Add("Abandonadas", ENTITY_STATE.TAKED_DOWN);
            StateCategories.Add("Quiere leer", EntityState.WantTo);
            //-repeat StateCategories.Add("Pausadas/En espera", ENTITY_STATE.QUEUE);
            //
            //- My Anime List
            //
            StateCategories.Add("Dropped", EntityState.TakedDown);
            StateCategories.Add("Plan to Watch", EntityState.WantTo);
            StateCategories.Add("On Hold", EntityState.Queue);
            StateCategories.Add("Currently Watching", EntityState.Watching);
            StateCategories.Add("Completed", EntityState.Watched);
            StateCategories.Add("Plan to Read", EntityState.WantTo);
            StateCategories.Add("Currently Reading", EntityState.Watching);
            //-repeat StateCategories.Add("Completed", ENTITY_STATE.WATCHED);
            //-repeat StateCategories.Add("On Hold", ENTITY_STATE.QUEUE);
            /*
             * TypeAnimeCategories Dictionary<string, <media_type>_TYPE>
             */
            AnimeTypesCategories = new Dictionary<string, ANIME_TYPE>();
            AnimeTypesCategories.Add("Serie", ANIME_TYPE.SERIE);
            AnimeTypesCategories.Add("TV", ANIME_TYPE.SERIE);
            AnimeTypesCategories.Add("OVA", ANIME_TYPE.OVA);
            AnimeTypesCategories.Add("Pelicula", ANIME_TYPE.MOVIE);
            AnimeTypesCategories.Add("Movie", ANIME_TYPE.MOVIE);
            AnimeTypesCategories.Add("Especial", ANIME_TYPE.SPECIAL);
            AnimeTypesCategories.Add("Special", ANIME_TYPE.SPECIAL);
            AnimeTypesCategories.Add("Web", ANIME_TYPE.WEB);
            AnimeTypesCategories.Add("ONA", ANIME_TYPE.WEB);
            // - Manga Below
            MangaTypeCategories = new Dictionary<string, MANGA_TYPE>();
            MangaTypeCategories.Add("Manga", MANGA_TYPE.MANGA);
            MangaTypeCategories.Add("Manhwa", MANGA_TYPE.MANHWA);
        }


    }
}
