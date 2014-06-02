using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeKakkoi.Core.Data.Json
{

    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected ICollection<T> RepositoryContent;

        protected Repository(ICollection<T> repositoryContent = null)
        {
            RepositoryContent = repositoryContent ?? new Collection<T>();
        }

        public T Add(T item)
        {
            throw new NotImplementedException();
        }
        
        public int AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Type RepositoryType()
        {
            throw new NotImplementedException();
        }

        protected abstract void SaveChanges();


    }

}
