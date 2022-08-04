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
    /// <typeparam name="TKey"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <typeparam name="TValue"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TValue']"/></typeparam>
    /// <param name="dictionary">A dictionary with keys of type
    /// <typeparamref name="TKey"/> and values of type
    /// <typeparamref name="TValue"/>.</param>
    /// <param name="key">
    /// <inheritdoc cref="IDictionary{TKey, TValue}.Add(TKey, TValue)"
    /// path="/param[@name='key']"/></param>
    /// <param name="value">
    /// <inheritdoc cref="IDictionary{TKey, TValue}.Add(TKey, TValue)"
    /// path="/param[@name='value']"/></param>
    /// <returns>The value for the key. This will be either the existing value
    /// for the key if the key is already in the dictionary, or the new value if
    /// the key was not in the dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> or
    /// <paramref name="key"/> is null.</exception>
    public static TValue GetOrAdd<TKey, TValue>(
      this IDictionary<TKey, TValue> dictionary,
      TKey key,
      TValue value)
    {
      if (dictionary == null) throw new ArgumentNullException("dictionary");
      if (key == null) throw new ArgumentNullException("key");

      TValue resultingValue = value;
      if (!dictionary.TryGetValue(key, out resultingValue))
        dictionary[key] = value;
      return resultingValue;
    }

    /// <inheritdoc cref="GetOrAdd{TKey, TValue}(IDictionary{TKey, TValue}, TKey, TValue)"/>
    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> by
    /// using the specified function if the key does not already exist. Returns
    /// the new value, or the existing value if the key exists.
    /// </summary>
    /// <param name="valueFactory">The function used to generate a value for the
    /// key.</param>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/>,
    /// <paramref name="key"/> or <paramref name="valueFactory"/> is null.
    /// </exception>
    public static TValue GetOrAdd<TKey, TValue>(
      this IDictionary<TKey, TValue> dictionary,
      TKey key,
      Func<TKey, TValue> valueFactory)
    {
      if (dictionary == null) throw new ArgumentNullException("dictionary");
      if (key == null) throw new ArgumentNullException("key");
      if (valueFactory == null) throw new ArgumentNullException("valueFactory");

      TValue resultingValue;
      if (!dictionary.TryGetValue(key, out resultingValue))
      {
        resultingValue = valueFactory(key);
        dictionary[key] = resultingValue;
      }
      return resultingValue;
    }

    /// <inheritdoc cref="GetOrAdd{TKey, TValue}(IDictionary{TKey, TValue}, TKey, Func{TKey, TValue})"/>
    /// <param name="factoryArgument">An argument value to pass into
    /// <paramref name="valueFactory"/>.</param>
    public static TValue GetOrAdd<TKey, TValue, TArg>(
      this IDictionary<TKey, TValue> dictionary,
      TKey key,
      Func<TKey, TArg, TValue> valueFactory,
      TArg factoryArgument)
    {
      if (dictionary == null) throw new ArgumentNullException("dictionary");
      if (key == null) throw new ArgumentNullException("key");
      if (valueFactory == null) throw new ArgumentNullException("valueFactory");

      TValue resultingValue;
      if (!dictionary.TryGetValue(key, out resultingValue))
      {
        resultingValue = valueFactory(key, factoryArgument);
        dictionary[key] = resultingValue;
      }
      return resultingValue;
    }
  }
}
