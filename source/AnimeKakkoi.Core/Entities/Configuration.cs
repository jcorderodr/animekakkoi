using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKakkoi.Core.Entities
{

    public class Configuration
    {

        public IEnumerable<string> AnimeCategories { get; set; }

        public IEnumerable<string> MangaCategories { get; set; }

        public IEnumerable<string> EntityTypes { get; set; }

        public IEnumerable<string> Entities { get; set; }

        public String ApplicationProductUrl { get; set; }

        public String ApplicationBugReport { get; set; }

        [DefaultValue("en-EN")]
        public CultureInfo ApplicationCulture { get; set; }

        public object UserUiFontsColor { get; set; }

        public object UserUiControlsFontsStyle { get; set; }

        public object UserUiFontsStyles { get; set; }

        [DefaultValue(false)]
        public Boolean UserInstantSearch { get; set; }

    }

}
