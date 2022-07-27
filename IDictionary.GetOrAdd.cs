// A part of the C# Language Syntactic Sugar suite.

using System.Collections.Generic;
using System;

namespace CLSS
{
  public static partial class IDictionaryGetOrAdd
  {
    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if
    /// the key does not already exist. Returns the new value, or the existing
    /// value if the key exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in
    /// <paramref name="source"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in
    /// <paramref name="source"/>.</typeparam>
    /// <param name="key">The key of the element to add.</param>
    /// <param name="value">The value to be added, if the key does not already
    /// exist.</param>
    /// <returns>The value for the key. This will be either the existing value
    /// for the key if the key is already in the dictionary, or the new value if
    /// the key was not in the dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or
    /// <paramref name="key"/> is null.</exception>
    public static TValue GetOrAdd<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      TValue value)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (key == null) throw new ArgumentNullException("key");

      TValue resultingValue = value;
      if (!source.TryGetValue(key, out resultingValue)) source[key] = value;
      return resultingValue;
    }

    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> by
    /// using the specified function if the key does not already exist. Returns
    /// the new value, or the existing value if the key exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in
    /// <paramref name="source"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in
    /// <paramref name="source"/>.</typeparam>
    /// <param name="key">The key of the element to add.</param>
    /// <param name="valueFactory">The function used to generate a value for the
    /// key.</param>
    /// <returns>The value for the key. This will be either the existing value
    /// for the key if the key is already in the dictionary, or the new value if
    /// the key was not in the dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>,
    /// <paramref name="key"/> or <paramref name="valueFactory"/> is null.
    /// </exception>
    public static TValue GetOrAdd<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      Func<TKey, TValue> valueFactory)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (key == null) throw new ArgumentNullException("key");
      if (valueFactory == null) throw new ArgumentNullException("valueFactory");

      TValue resultingValue;
      if (!source.TryGetValue(key, out resultingValue))
      {
        resultingValue = valueFactory(key);
        source[key] = resultingValue;
      }
      return resultingValue;
    }

    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> by
    /// using the specified function if the key does not already exist. Returns
    /// the new value, or the existing value if the key exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in
    /// <paramref name="source"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in
    /// <paramref name="source"/>.</typeparam>
    /// <typeparam name="TArg">The type of an argument to pass into
    /// <paramref name="valueFactory"/>.</typeparam>
    /// <param name="key">The key of the element to add.</param>
    /// <param name="valueFactory">The function used to generate a value for the
    /// key.</param>
    /// <param name="factoryArgument">An argument value to pass into
    /// <paramref name="valueFactory"/>.</param>
    /// <returns>The value for the key. This will be either the existing value
    /// for the key if the key is already in the dictionary, or the new value if
    /// the key was not in the dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>,
    /// <paramref name="key"/> or <paramref name="valueFactory"/> is null.
    /// </exception>
    public static TValue GetOrAdd<TKey, TValue, TArg>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      Func<TKey, TArg, TValue> valueFactory,
      TArg factoryArgument)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (key == null) throw new ArgumentNullException("key");
      if (valueFactory == null) throw new ArgumentNullException("valueFactory");

      TValue resultingValue;
      if (!source.TryGetValue(key, out resultingValue))
      {
        resultingValue = valueFactory(key, factoryArgument);
        source[key] = resultingValue;
      }
      return resultingValue;
    }
  }
}
