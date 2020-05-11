using System;
using System.Collections.Generic;

namespace CC.Base.Extensions
{
    public static class PrimitiveExtensions
    {
        public static T IfNotNull<T>(this T obj, Action<T> action)
        {
            if (obj != null)
                action(obj);
            return obj;
        }

        public static void InsertOrUpdate<TKey,TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

    }
}