using System;
using System.Collections.Generic;



namespace ApisFlorea.Core.Collections.Generic
{
    /// <summary>
    /// 辞書の拡張機能を提供します。
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 指定されたキーに一致する値を取得します。キーが見つからない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="TKey">キーの型</typeparam>
        /// <typeparam name="TValue">値の型</typeparam>
        /// <param name="dictionary">辞書</param>
        /// <param name="key">キー</param>
        /// <param name="defaultValue">キーが見つからなかった場合の既定値</param>
        /// <returns>値</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null)        throw new ArgumentNullException(nameof(key));

            TValue value;
            return  dictionary.TryGetValue(key, out value)
                ?   value
                :   defaultValue;
        }


        /// <summary>
        /// 指定されたキーに一致する値を取得します。キーが見つからない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="TKey">キーの型</typeparam>
        /// <typeparam name="TValue">値の型</typeparam>
        /// <param name="dictionary">辞書</param>
        /// <param name="key">キー</param>
        /// <param name="defaultValue">キーが見つからなかった場合の既定値</param>
        /// <returns>値</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null)        throw new ArgumentNullException(nameof(key));

            TValue value;
            return  dictionary.TryGetValue(key, out value)
                ?   value
                :   defaultValue;
        }
    }
}