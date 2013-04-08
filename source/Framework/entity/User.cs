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
            aux.Add(source);
            this.Sources = aux.ToArray();
        }

    }
}
