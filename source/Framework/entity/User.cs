using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class User : Entity
    {

        public User()
        {
            Sources = new string[0];
        }

        public String[] Sources { get; set; }

        public void AddSource(string source)
        {
            List<string> aux = this.Sources.ToList();
            if (!aux.Contains(source))
                aux.Add(source);
            this.Sources = aux.ToArray();
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, Sources {2}", Codigo, Name, Sources.Length);
        }

    }
}
