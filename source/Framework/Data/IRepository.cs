using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Framework.repo
{
    /// <summary>
    /// An Repository's skeleton.
    /// </summary>
    /// <typeparam name="T">Framework.entity.EntitySource</typeparam>
    public interface IRepository<T> where T : class
    {

        T Add(T item);

        //int AddRange(IList<T> items);

        void Change(T item);

        void Remove(T item);

        IList<T> GetAll();

        IList<T> LookUp(string itemName);

        Type RepositoryType();

    }
}
