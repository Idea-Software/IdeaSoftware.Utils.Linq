using System;
using System.Collections.Generic;
using System.Linq;

namespace IdeaSoftware.Utils.Linq
{
    public static class Enumerations
    {
        /// <summary>
        /// Provides index when looping through collection
        /// </summary>
        /// <param name="collection">Collection to enumerate.</param>
        /// <param name="action">Delegate to call for each item.</param>
        public static void Each<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in collection)
            {
                action(item, index);
                index++;
            }
        }

        /// <summary>
        /// Enumerated collection providing iteration metadata.
        /// </summary>
        /// <param name="collection">Collection to enumerate.</param>
        /// <param name="action">Delegate to call for each item.</param>
        public static void Each<T>(this IEnumerable<T> collection, Action<Item<T>> action)
        {
            var enumeratedCollection = collection.ToList();
            var index = 0;
            foreach (var item in enumeratedCollection)
            {
                action(new Item<T>
                {
                    Value = item,
                    Index = index,
                    IsFirst = index == 0,
                    IsLast = index == enumeratedCollection.Count - 1
                });
                index++;
            }
        }
        public class Item<T>
        {
            public T Value { get; set; }
            public int Index { get; internal set; }
            public bool IsFirst { get; internal set; }
            public bool IsLast { get; internal set; }
        }
    }

}
