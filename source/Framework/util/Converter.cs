using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.util
{
    /// <summary>
    /// 
    /// </summary>
    public class Converter
    {

        /// <summary>
        /// Converts a list of elements in a EntitySource's base list.
        /// </summary>
        /// <param name="source">List<Object> source</param>
        /// <returns>List<entity.EntitySource></returns>
        public static List<entity.EntitySource> To(List<Object> source)
        {
            return source.ConvertAll(new Converter<object, entity.EntitySource>(ObjectToType));
        }

        /// <summary>
        /// Converts a list of EntitySource's base list in a object-based list.
        /// </summary>
        /// <param name="source">List<entity.EntitySource></param>
        /// <returns>List<Object></returns>
        public static List<Object> ToObject(List<entity.EntitySource> source)
        {
            return source.ConvertAll(new Converter<entity.EntitySource, object>(TypeToObject));
        }

        #region Private Functions

        private static entity.EntitySource ObjectToType(object obj)
        {
            return (entity.EntitySource)obj;
        }

        private static object TypeToObject(entity.EntitySource item)
        {
            return (object)item;
        }

        #endregion

    }
}
