using System;
using System.Collections.Generic;
using AnimeKakkoi.Core.Entities;
using Newtonsoft.Json;

namespace AnimeKakkoi.Core.Data.Json
{

    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {

        private const String JsonDataString = "AnimeRepository.akp";

        public AnimeRepository()
        {
            var dataConnection = IO.AkConfiguration.ApplicationDataFolder + JsonDataString;
            var content = IO.FileManager.OpenOrCreateStream(dataConnection);
            var context = JsonConvert.DeserializeObject<IList<Anime>>(content.Result);
            base.RepositoryContent = context;
        }

        protected override void SaveChanges()
        {
            JsonConvert.SerializeObject(RepositoryContent, Formatting.Indented);
        }

    }

}
