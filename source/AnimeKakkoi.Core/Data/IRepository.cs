
using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Core.Data
{
    public interface IRepository<T> where T : class
    {

        T Add(T item);

        int AddRange(IEnumerable<T> items);

        void Change(T item);

        int Change(IEnumerable<T> items);

        IEnumerable<T> LookUp(String nameCriteria);

        void Remove(T item);

        IEnumerable<T> Get(int id);

        IEnumerable<T> GetAll();

        Type RepositoryType();

    }
}
