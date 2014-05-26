using System;
using System.Collections.Generic;
using AnimeKakkoi.Framework.Entities;

namespace AnimeKakkoi.Framework.util
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
        public static List<EntitySource> To(List<Object> source)
        {
            return source.ConvertAll(new Converter<object, EntitySource>(ObjectToType));
        }

        /// <summary>
        /// Converts a list of EntitySource's base list in a object-based list.
        /// </summary>
        /// <param name="source">List<entity.EntitySource></param>
        /// <returns>List<Object></returns>
        public static List<Object> ToObject(List<EntitySource> source)
        {
            return source.ConvertAll(new Converter<EntitySource, object>(TypeToObject));
        }

        #region Private Functions

        private static global::AnimeKakkoi.Framework.Entities.EntitySource ObjectToType(object obj)
        {
            return (global::AnimeKakkoi.Framework.Entities.EntitySource)obj;
        }

        private static object TypeToObject(global::AnimeKakkoi.Framework.Entities.EntitySource item)
        {
            return (object)item;
        }

        #endregion

    }
}
