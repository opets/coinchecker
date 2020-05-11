using System;
using System.Collections.Generic;
using System.Linq;

namespace CC.Base.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Foreach<TSource>(this IEnumerable<TSource> source, Action<TSource> predicate)
        {
            foreach (var element in source.EmptyIfNull())
                predicate(element);
        }

        public static IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> source) => 
            source ?? Enumerable.Empty<TSource>();
    }
}