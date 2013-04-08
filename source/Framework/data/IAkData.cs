using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.data
{
    public interface IAkData<T> where T : class, new()
    {
        void AddItem(T entity);
        void DeleteItem(T entity);
    }
}
