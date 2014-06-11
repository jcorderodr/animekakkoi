using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeKakkoi.Core.Data.Json
{

    public abstract class Repository<T> : IDisposable, IRepository<T> where T : Entities.Entity
    {

        protected ICollection<T> RepositoryContent;

        //ApplicationDataFolder + Repo
        private String _nameOrLocation;

        protected Repository(ICollection<T> repositoryContent = null)
        {
            RepositoryContent = repositoryContent ?? new Collection<T>();
        }

        protected Repository(String nameOrLocation)
        {
            _nameOrLocation = IO.AkConfiguration.ApplicationDataFolder + nameOrLocation;
            var content = IO.FileManager.OpenOrCreateStream(_nameOrLocation);
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(content.Result) ?? new T[] { };
            RepositoryContent = context.ToList();
        }

        public void Dispose()
        {
            RepositoryContent = null;
        }

        public T Add(T item)
        {

            return item;
        }

        public int AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                item.Codigo = GetNewId();
                RepositoryContent.Add(item);
            }
            this.SaveChanges();
            return items.Count();
        }

        public void Change(T item)
        {
            throw new NotImplementedException();
        }

        public int Change(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> LookUp(String nameCriteria)
        {
            return RepositoryContent.Where(p => p.ToString().Contains(nameCriteria));
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(int id)
        {
            return RepositoryContent.Where(p => p.Codigo == id);
        }

        public IEnumerable<T> GetAll()
        {
            return RepositoryContent;
        }

        public Type RepositoryType()
        {
            return typeof(T);
        }

        protected virtual void SaveChanges()
        {
            var content = JsonConvert.SerializeObject(RepositoryContent, Formatting.Indented);
            IO.FileManager.SaveStream(_nameOrLocation, content);
        }

        protected abstract int GetNewId();

    }

}
