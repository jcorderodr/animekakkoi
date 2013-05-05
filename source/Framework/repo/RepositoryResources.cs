using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.repo
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryResources
    {

        public RepositoryResources()
        {
        }

        public bool ReleaseItems()
        {
            using (Framework.repo.xml.AnimeRepository repo = new Framework.repo.xml.AnimeRepository())
            {
                repo.RemoveAll();
            }
            using (Framework.repo.xml.MangaRepository repo = new Framework.repo.xml.MangaRepository())
            {
                repo.RemoveAll();
            }
            return true;
        }

        public bool ReleaseUserSettings()
        {
            using (Framework.repo.xml.UserRepository repo = new Framework.repo.xml.UserRepository())
            {
                repo.ReleaseData();
            }
            //TODO: release user data
            return true;
        }

        public bool ReleaseDatabase()
        {
            ReleaseItems();
            ReleaseUserSettings();
            return true;
        }


    }
}
