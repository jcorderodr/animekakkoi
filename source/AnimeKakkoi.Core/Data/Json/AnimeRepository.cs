using System;
using System.Linq;
using System.Collections.Generic;
using AnimeKakkoi.Core.Entities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AnimeKakkoi.Core.Data.Json
{

    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {


        public AnimeRepository()
            :base("AnimeRepository.akc")
        {

        }


        protected override int GetNewId()
        {
            var last = RepositoryContent.OrderBy(p => p.Codigo).LastOrDefault();
            return last == null ? 1 : last.Codigo++;
        }

    }

}
