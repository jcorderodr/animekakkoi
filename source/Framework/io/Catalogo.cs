using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Framework.IO
{
    /// <summary>
    /// Represent a Catalog and Provides mechanism for getting Configurables values.
    /// </summary>
    [Serializable]
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
            List<Catalog> list = new List<Catalog>();

            //list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = AkConfiguration.GetSetting("entities");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog()
                {
                    Id = i + 1 + "",
                    Value = aux2[i].Trim(),
                    Description = aux2[i].Trim()
                });

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetEntitiesStateTypes()
        {
            List<Catalog> list = new List<Catalog>();

            // list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = AkConfiguration.GetSetting("entities_types");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog()
                {
                    Id = i + 1 + "",
                    Value = aux2[i].Trim(),
                    Description = aux2[i].Trim()
                });

            return list;
        }

        /// <summary>
        /// Gets all Entities but filtered by the Input's Language.
        /// <seealso cref="GetEntitiesStateTypes"/>
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetEntitiesTypesByLanguage()
        {
            List<Catalog> list = new List<Catalog>();

            string aux = AkConfiguration.GetSetting("entities_types");

            Language lg = new Language();

            string[] aux2 = aux.Split(',');

            for (int i = 0; i < aux2.Length; i++)
            {
                list.Add(new Catalog()
                {
                    Id = i + 1 + "",
                    Value = aux2[i].Trim(),
                    Description = lg.MessagesLibrary[aux2[i].Trim()]
                });
            }

            return list;
        }

        /// <summary>
        /// Gets all the categories types of animes.
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetAnimeCategoriesTypes()
        {
            List<Catalog> list = new List<Catalog>();

            // list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = AkConfiguration.GetSetting("anime_categories");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog()
                {
                    Id = i + 1 + "",
                    Value = aux2[i],
                    Description = aux2[i]
                });

            return list;
        }

        /// <summary>
        ///  Gets all the categories types of mangas.
        /// </summary>
        /// <returns></returns>
        public static List<Catalog> GetMangaCategoriesTypes()
        {
            List<Catalog> list = new List<Catalog>();

            //list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = AkConfiguration.GetSetting("manga_categories");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog()
                {
                    Id = i + 1 + "",
                    Value = aux2[i],
                    Description = aux2[i]
                });

            return list;
        }

    }
}
