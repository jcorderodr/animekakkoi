using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.io
{
    [Serializable]
    public class Catalog
    {

        public string Id { get; set; }

        public String Value { get; set; }

        public String Description { get; set; }

        public String[] GetEntitiesValidTypes()
        {
            return new string[] { "Anime", "Manga" };
        }

        public List<Catalog> GetEntitiesStateTypes()
        {
            List<Catalog> list = new List<Catalog>();

            list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = io.Configuration.GetSetting("entities_types");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog() { Id = i + 1 + "", Value = aux2[i].Trim() });

            return list;
        }

        public List<Catalog> GetAnimeCategoriesTypes()
        {
            List<Catalog> list = new List<Catalog>();

            list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = io.Configuration.GetSetting("anime_categories");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog() { Id = i + 1 + "", Value = aux2[i] });

            return list;
        }

        public List<Catalog> GetMangaCategoriesTypes()
        {
            List<Catalog> list = new List<Catalog>();

            list.Add(new Catalog() { Id = 0 + "", Value = "--" });

            string aux = io.Configuration.GetSetting("manga_categories");
            string[] aux2 = aux.Split(',');
            for (int i = 0; i < aux2.Length; i++)
                list.Add(new Catalog() { Id = i + 1 + "", Value = aux2[i] });

            return list;
        }

    }
}
