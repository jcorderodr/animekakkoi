using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;

namespace Framework.media
{
    public abstract class SourceBase
    {

        public readonly Dictionary<string, MANGA_TYPE> MangaTypeCategories;

        public readonly Dictionary<string, ANIME_TYPE> AnimeTypesCategories;

        public readonly Dictionary<string, ENTITY_STATE> StateCategories;

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
             * There are some reapeated labels.
             */
            StateCategories = new Dictionary<string, ENTITY_STATE>();
            //
            // - McAnime
            //
            StateCategories.Add("La abandone", ENTITY_STATE.TAKED_DOWN);
            StateCategories.Add("La quiero ver", ENTITY_STATE.WANT_TO);
            StateCategories.Add("La deje de ver temporalmente", ENTITY_STATE.QUEUE);
            StateCategories.Add("La estoy viendo", ENTITY_STATE.WATCHING);
            StateCategories.Add("La vi completa", ENTITY_STATE.WATCHED);
            StateCategories.Add("La quiero leer", ENTITY_STATE.WANT_TO);
            StateCategories.Add("La estoy leyendo", ENTITY_STATE.WATCHING);
            StateCategories.Add("La leí completa", ENTITY_STATE.WATCHED);
            StateCategories.Add("La deje de leer temporalmente", ENTITY_STATE.QUEUE);
            //-repeat StateCategories.Add("La abandone", ENTITY_STATE.TAKED_DOWN);
            //
            //- McAnime Kronos
            //
            StateCategories.Add("Viendo", ENTITY_STATE.WATCHING);
            StateCategories.Add("Completadas", ENTITY_STATE.WATCHED);
            StateCategories.Add("Pausadas/En espera", ENTITY_STATE.QUEUE);
            StateCategories.Add("Quiere ver", ENTITY_STATE.WANT_TO);
            StateCategories.Add("Abandonadas", ENTITY_STATE.TAKED_DOWN);
            StateCategories.Add("Leyendo", ENTITY_STATE.WATCHING);
            //-repeat StateCategories.Add("Completadas", ENTITY_STATE.WATCHED);
            //-repeat StateCategories.Add("Abandonadas", ENTITY_STATE.TAKED_DOWN);
            StateCategories.Add("Quiere leer", ENTITY_STATE.WANT_TO);
            //-repeat StateCategories.Add("Pausadas/En espera", ENTITY_STATE.QUEUE);

            /*
            * TypeAnimeCategories Dictionary<string, <media_type>_TYPE>
            */
            AnimeTypesCategories = new Dictionary<string, ANIME_TYPE>();
            AnimeTypesCategories.Add("Serie", ANIME_TYPE.SERIE);
            AnimeTypesCategories.Add("OVA", ANIME_TYPE.OVA);
            AnimeTypesCategories.Add("Pelicula", ANIME_TYPE.MOVIE);
            AnimeTypesCategories.Add("Especial", ANIME_TYPE.SPECIAL);
            AnimeTypesCategories.Add("Web", ANIME_TYPE.WEB);
            // - Manga Below
            MangaTypeCategories = new Dictionary<string, MANGA_TYPE>();
            MangaTypeCategories.Add("Manga", MANGA_TYPE.MANGA);
            MangaTypeCategories.Add("Manhwa", MANGA_TYPE.MANHWA);
        }


    }
}
