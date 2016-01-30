using System.Collections;
using System.Collections.Generic;

namespace MicroserviceMatrixDSL.FunctionalToolkit.Collections
{
    /// <summary>
    ///     Dictionary that returns default value instead of throwing exception if key is not available
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class DefaultableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly TValue _defaultValue;
        private readonly IDictionary<TKey, TValue> _dictionary;

        public DefaultableDictionary(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            _dictionary = dictionary;
            _defaultValue = defaultValue;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dictionary.Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Remove(item);
        }

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;

        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!_dictionary.TryGetValue(key, out value))
            {
                value = _defaultValue;
            }

            return true;
        }

        public TValue this[TKey key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (KeyNotFoundException)
                {
                    return _defaultValue;
                }
            }

            set { _dictionary[key] = value; }
        }

        public ICollection<TKey> Keys => _dictionary.Keys;

        public ICollection<TValue> Values
        {
            get
            {
                var values = new List<TValue>(_dictionary.Values)
                {
                    _defaultValue
                };
                return values;
            }
        }
    }

    public static class DefaultableDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> WithDefaultValue<TValue, TKey>(
            this IDictionary<TKey, TValue> dictionary, TValue defaultValue)
        {
            return new DefaultableDictionary<TKey, TValue>(dictionary, defaultValue);
        }
    }
}