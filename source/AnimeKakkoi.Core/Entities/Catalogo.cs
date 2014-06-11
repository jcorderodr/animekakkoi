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
        /// Gets the valids types of Entities.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Catalog> GetEntitiesValidTypes()
        {
            var values = AkConfiguration.GetSetting("Entities");

            var aux2 = values.Split(',');

            return aux2.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t.Trim(),
                    Description = t.Trim()
                }).ToList();
        }

        public static IEnumerable<Catalog> GetEntitiesStateTypes()
        {
            var values = Enum.GetNames(typeof(Entities.EntityState));

            return values.Select((t, i) => new Catalog()
                {
                    Id = i + 1 + "",
                    Value = t.Trim(),
                    Description = t.Trim()
                }).ToList();
        }

        public static IEnumerable<Catalog> GetEntitiesStateTypes(Lang.Language language)
        {
            var values = Enum.GetNames(typeof(Entities.EntityState));

            return values.Select((t, i) => new Catalog()
            {
                Id = i + 1 + "",
                Value = t.Trim(),
                Description = language.MessagesLibrary[t.Trim()]
            }).ToList();
        }

        /// <summary>
        /// Gets all the categories types of animes.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Catalog> GetAnimeCategoriesTypes()
        {
            var values = AkConfiguration.GetSetting("AnimeCategories");

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
        public static IEnumerable<Catalog> GetMangaCategoriesTypes()
        {
            var values = AkConfiguration.GetSetting("MangaCategories");

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
