using System;
using AnimeKakkoi.Core.Helpers;

namespace AnimeKakkoi.Core.Entities
{
    public abstract class EntitySource : Entity
    {

        public EntityState State { get; set; }

        public int Rating { get; set; }

        public String[] Episodes { get; set; }

        public bool Favorite { get; set; }

        public String Comment { get; set; }

        /// <summary>
        /// Gets or sets a string that represents the progress in the format x/xx.
        /// </summary>
        public override String ProgressString
        {
            get
            {
                return String.Format("{0}{2}{1}", Episodes[0], Episodes[1], EntityProperties.EPISODE_CHAPTER_SEPARATOR);
            }
            set
            {
                string[] temp = value.Contains(EntityProperties.EPISODE_CHAPTER_SEPARATOR.ToString())
                                    ? value.Split(EntityProperties.EPISODE_CHAPTER_SEPARATOR)
                                    : String.Format("{0}{2}{1}", value, EntityProperties.EPISODE_CHAPTER_EMPTYCHAR,
                                                    EntityProperties.EPISODE_CHAPTER_SEPARATOR)
                                            .Split(EntityProperties.EPISODE_CHAPTER_SEPARATOR);
                Episodes = temp;
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
