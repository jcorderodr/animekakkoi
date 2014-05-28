using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeKakkoi.Core.Entities;

namespace AnimeKakkoi.Core.Data.Json
{
    public interface IAnimeRpository : IRepository<Anime>
    {
       
    }

    public class AnimeRpository : Repository<Anime>, IAnimeRpository
    {


        public AnimeRpository() 
            : base(new Collection<Anime>())
        {

        }

        protected override void SaveChanges()
        {
            throw new NotImplementedException();
        }

    }

}
