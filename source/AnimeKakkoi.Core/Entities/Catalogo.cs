using System;
using System.Collections.Generic;
using System.Linq;
using AnimeKakkoi.Core.IO;

namespace AnimeKakkoi.Core.Entities
{
    /// <summary>
    /// Represent a Catalog and Provides mechanism for getting Configurables values.
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// InnerValue
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// OuterValue
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets the valids types of entities.
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetEntitiesValidTypes()
        {
            var values = AkConfiguration.GetSetting("entities");

            var aux2 = values.Split(',');

            return aux2.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t.Trim(),
                    Description = t.Trim()
                }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetEntitiesStateTypes()
        {
            string values = AkConfiguration.GetSetting("entities_types");
            string[] aux2 = values.Split(',');

            return aux2.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t.Trim(),
                    Description = t.Trim()
                }).ToList();
        }

        /// <summary>
        /// Gets all the categories types of animes.
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetAnimeCategoriesTypes()
        {
            var values = AkConfiguration.GetSetting("anime_categories");

            var aux2 = values.Split(',');

            return aux2.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t,
                    Description = t
                }).ToList();
        }

        /// <summary>
        ///  Gets all the categories types of mangas.
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetMangaCategoriesTypes()
        {
            var values = AkConfiguration.GetSetting("manga_categories");

            var aux2 = values.Split(',');

            return aux2.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t,
                    Description = t
                }).ToList();
        }

    }
}
