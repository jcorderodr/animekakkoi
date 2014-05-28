
using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Core.Data
{
    public interface IRepository<T> where T : class
    {

        T Add(T item);

        int AddRange(IList<T> items);

        void Change(T item);

        void Remove(T item);

        IEnumerable<T> Get(int id);

        IEnumerable<T> GetAll();

        Type RepositoryType();

    }
}
