using System;
using System.Linq;
using AnimeKakkoi.Core.Helpers;

namespace AnimeKakkoi.Core.Entities
{
    public abstract class EntitySource : Entity
    {

        public EntitySource()
        {
            Episode = new Episodes();
        }

        public class Episodes
        {
            [System.ComponentModel.DefaultValue("0")]
            public String Progress;

            [System.ComponentModel.DefaultValue(EntityProperties.EPISODE_EMPTYCHAR)]
            public String Last;
        }

        public EntityState State { get; set; }

        [System.ComponentModel.DefaultValue(0)]
        public int Rating { get; set; }

        public Episodes Episode { get; set; }

        public bool Favorite { get; set; }

        public String Comment { get; set; }

        /// <summary>
        /// Gets or sets a string that represents the progress in the format x/xx.
        /// </summary>
        public override String ProgressString
        {
            get
            {
                return String.Format("{0}{2}{1}", Episode.Progress, Episode.Last, EntityProperties.EPISODE_SEPARATOR);
            }
            set
            {
                string[] temp = value.Contains(EntityProperties.EPISODE_SEPARATOR.ToString())
                                    ? value.Split(EntityProperties.EPISODE_SEPARATOR)
                                    : String.Format("{0}{2}{1}", value, EntityProperties.EPISODE_EMPTYCHAR,
                                                    EntityProperties.EPISODE_SEPARATOR)
                                            .Split(EntityProperties.EPISODE_SEPARATOR);
                Episode.Progress = temp.First().Trim();
                Episode.Last = temp.Last().Trim();
            }
        }

        public override string ToString()
        {
            string fav = Favorite ? EntityProperties.ENTITY_FAVORITE_MARK + " " : String.Empty;
            return String.Format("{0} {3}[Rat:{2} / {1}]", Name, State, Rating, fav);
        }

        public virtual void FromString(string text)
        {
            int init = 0, end = 0;

            this.Favorite = text.Contains(EntityProperties.ENTITY_FAVORITE_MARK);
            this.Name = this.Favorite ?
                text.Substring(0, text.IndexOf(EntityProperties.ENTITY_FAVORITE_MARK, System.StringComparison.Ordinal) - 1)
                : text.Substring(0, text.IndexOf("[", System.StringComparison.Ordinal) - 1);

            init = text.LastIndexOf(":", System.StringComparison.Ordinal);
            end = text.LastIndexOf("/", System.StringComparison.Ordinal);
            this.Rating = StringHelper.GetOnlyNumbers(text.Substring(init, end - init));

            init = end + 1;
            end = text.LastIndexOf("]", System.StringComparison.Ordinal);
            this.State = (EntityState)Enum.Parse(typeof(EntityState), text.Substring(init, end - init));
        }

    }
}
