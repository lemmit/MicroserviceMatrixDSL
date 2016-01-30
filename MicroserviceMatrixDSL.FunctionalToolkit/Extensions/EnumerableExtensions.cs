using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroserviceMatrixDSL.FunctionalToolkit.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AndThen<T>(this IEnumerable<T> collection, T nextElem)
        {
            foreach (var elem in collection)
            {
                yield return elem;
            }
            yield return nextElem;
        }

        public static IEnumerable<T> AndThen<T>(this IEnumerable<T> collection, IEnumerable<T> nextCollection)
        {
            foreach (var elem in collection)
            {
                yield return elem;
            }
            foreach (var elem in nextCollection)
            {
                yield return elem;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            action = action ?? (elem => { });
            foreach (var elem in collection)
            {
                action(elem);
            }
        }

        public static string Stringify<T>(this IEnumerable<T> collection, Func<T, string> printElemFunc = null,
            string separator = ", ")
        {
            var list = collection.ToList();
            if (!list.Any()) return string.Empty;
            //use sentinel function if none has been provided
            var printFunc = printElemFunc ??
                            (elem => elem.ToString());

            var head = printFunc(list.First());
            var tail = list
                .Skip(1)
                .Aggregate("", (acc, val) => acc + separator + printFunc(val));
            return head + tail;
        }

        public static IEnumerable<string> RemoveComments(this IEnumerable<string> lines)
        {
            return lines.Where(line => !line.Trim().StartsWith("//"));
        }

        public static IEnumerable<string> SplitLines(this IEnumerable<string> lines, char separator = ' ')
        {
            return lines.SelectMany(line => line.Split(separator));
        }

        public static IEnumerable<string> FilterWhitespaces(this IEnumerable<string> strings)
        {
            return strings.Where(token => !string.IsNullOrWhiteSpace(token) && !string.IsNullOrEmpty(token));
        }

        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            return strings.Select(token => token.Trim());
        }
    }
}