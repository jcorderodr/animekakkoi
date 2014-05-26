namespace AnimeKakkoi.Framework.Repo
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
            using (global::AnimeKakkoi.Framework.Repo.xml.AnimeRepository repo = new global::AnimeKakkoi.Framework.Repo.xml.AnimeRepository())
            {
                repo.RemoveAll();
            }
            using (global::AnimeKakkoi.Framework.Repo.xml.MangaRepository repo = new global::AnimeKakkoi.Framework.Repo.xml.MangaRepository())
            {
                repo.RemoveAll();
            }
            return true;
        }

        public bool ReleaseUserSettings()
        {
            using (global::AnimeKakkoi.Framework.Repo.xml.UserRepository repo = new global::AnimeKakkoi.Framework.Repo.xml.UserRepository())
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
