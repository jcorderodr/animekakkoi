using System;
using System.Collections.ObjectModel;
using AnimeKakkoi.Core.Entities;

namespace AnimeKakkoi.Core.Data.Json
{
    public class MangaRepository : Repository<Manga>, IMangaRepository
    {

        public MangaRepository()
            :base(new Collection<Manga>())
        {
            
        }

        protected override void SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
