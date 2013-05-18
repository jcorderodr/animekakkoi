using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public abstract class EntitySource : Entity
    {

        public ENTITY_STATE State { get; set; }

        public int Rating { get; set; }

        public bool Favorite { get; set; }

        public String Comment { get; set; }

        //public object Category { get; set; }

        //Add gusto/genero

        public override string ToString()
        {
            return String.Format("{0}, [Rat:{2} / {1}]", Name, State, Rating);
        }
    }
}
