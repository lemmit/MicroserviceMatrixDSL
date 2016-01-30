using System.Collections;
using System.Collections.Generic;

namespace MicroserviceMatrixDSL.FunctionalToolkit.Collections
{
    public class VerboseDictionary<T, T1> : IDictionary<T, T1>
    {
        private readonly IDictionary<T, T1> _dictionary;

        public VerboseDictionary(IDictionary<T, T1> dictionary)
        {
            _dictionary = dictionary;
        }

        public T1 this[T key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (KeyNotFoundException e)
                {
                    throw new KeyNotFoundException(key.ToString(), e);
                }
            }

            set { _dictionary[key] = value; }
        }

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;
        public ICollection<T> Keys => _dictionary.Keys;
        public ICollection<T1> Values => _dictionary.Values;

        public void Add(KeyValuePair<T, T1> item)
        {
            _dictionary.Add(item);
        }

        public void Add(T key, T1 value)
        {
            _dictionary.Add(key, value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<T, T1> item)
        {
            return _dictionary.Contains(item);
        }

        public bool ContainsKey(T key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<T, T1>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<T, T1>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public bool Remove(KeyValuePair<T, T1> item)
        {
            return _dictionary.Remove(item);
        }

        public bool Remove(T key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(T key, out T1 value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}