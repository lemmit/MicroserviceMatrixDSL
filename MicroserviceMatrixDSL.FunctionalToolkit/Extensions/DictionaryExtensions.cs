using MicroserviceMatrixDSL.FunctionalToolkit.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MicroserviceMatrixDSL.FunctionalToolkit.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<T, T1> ToVerboseDictionary<T, T1>(this IDictionary<T, T1> dict)
        {
            return new VerboseDictionary<T,T1>(dict);
        }

        public static IDictionary<T, T1> ToDefaultableDictionary<T, T1>(this IDictionary<T, T1> dict, T1 defaultValue)
        {
            return new DefaultableDictionary<T, T1>(dict, defaultValue);
        }

        public static IDictionary<T, T1> ToDefaultableDictionary<T, T1>(this IReadOnlyDictionary<T, T1> dict, T1 defaultValue)
        {
            return new DefaultableDictionary<T, T1>(dict.ToDictionary(), defaultValue);
        }


        public static Dictionary<T, T1> ToDictionary<T, T1>(this IReadOnlyDictionary<T, T1> dict)
        {
            return dict.ToDictionary(elem => elem.Key, elem => elem.Value);
        }

        public static IDictionary<T, T1> ToDictionary<T, T1>(this IEnumerable<KeyValuePair<T, T1>> dict)
        {
            return dict.ToDictionary(elem => elem.Key, elem => elem.Value);
        }



    }
}
