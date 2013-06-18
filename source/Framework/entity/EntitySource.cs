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

        public String[] Episodes { get; set; }

        public bool Favorite { get; set; }

        public String Comment { get; set; }

        /// <summary>
        /// Gets or sets an string that represent the progress in the format x/xx.
        /// </summary>
        public override String ProgressString
        {
            get
            {
                return String.Format("{0}{2}{1}", Episodes[0], Episodes[1], EntityProperties.EPISODE_CHAPTER_SEPARATOR);
            }
            set
            {
                string[] temp = new string[2];
                if (value.Contains(EntityProperties.EPISODE_CHAPTER_SEPARATOR))
                    temp = value.Split(EntityProperties.EPISODE_CHAPTER_SEPARATOR);
                else
                    temp = String.Format("{0}{2}{1}", value, EntityProperties.EPISODE_CHAPTER_EMPTYCHAR, EntityProperties.EPISODE_CHAPTER_SEPARATOR).Split(EntityProperties.EPISODE_CHAPTER_SEPARATOR);

                Episodes = temp;
            }
        }

        public override string ToString()
        {
            string fav = Favorite ? EntityProperties.ENTITY_FAVORITE_MARK + " " : "";
            return String.Format("{0} {3}[Rat:{2} / {1}]", Name, State, Rating, fav);
        }

        public virtual void FromString(string text)
        {
            int init = 0, end = 0;

            this.Favorite = text.Contains(EntityProperties.ENTITY_FAVORITE_MARK);
            if (this.Favorite)
                this.Name = text.Substring(0, text.IndexOf(EntityProperties.ENTITY_FAVORITE_MARK) - 1);
            else
                this.Name = text.Substring(0, text.IndexOf("[") - 1);

            init = text.LastIndexOf(":");
            end = text.LastIndexOf("/");
            this.Rating = Framework.util.Expression.GetOnlyNumbers(text.Substring(init, end - init));

            init = end + 1;
            end = text.LastIndexOf("]");
            this.State = (Framework.entity.ENTITY_STATE)Enum.Parse(typeof(Framework.entity.ENTITY_STATE), text.Substring(init, end - init));
        }

    }
}
