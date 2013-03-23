using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.data
{
    public class Catalog
    {
        public string Id { get; set; }
        public String Value { get; set; }
        public String Description { get; set; }

        public List<Catalog> GetAnimeTypes()
        {
            //DataTable data = new DataTable();
            //data.Columns.AddRange(new DataColumn[] { new DataColumn("Id"), new DataColumn("Value") });

            //data.Rows.Add("1", "queue");
            //data.Rows.Add("1", "queue");
            //data.Rows.Add("1", "queue");

            List<Catalog> list = new List<Catalog>();
            string aux = io.Configuration.GetSetting("anime_types");
            string[] aux2 = aux.Split(',');
            for(int i = 0; i< aux2.Length; i++)
                list.Add(new Catalog() { Id = i+1+"", Value = aux2[i] });

            return list;
        }

    }
}
