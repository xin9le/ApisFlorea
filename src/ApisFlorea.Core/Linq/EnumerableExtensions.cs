using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;



namespace ApisFlorea.Core.Linq
{
    /// <summary>
    /// IEnumerable&lt;T&gt;の拡張機能を提供します。
    /// </summary>
    public static class EnumerableExtensions
    {
        #region ForEach
        /// <summary>
        /// コレクションの各要素に対して指定されたアクションを実行します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <param name="action">実行する処理</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (action == null)     throw new ArgumentNullException(nameof(action));
            foreach (var item in collection)
                action(item);
        }
        #endregion


        #region Do
        /// <summary>
        /// コレクションの各要素に対して指定されたアクションを実行し、次に繋げます。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <param name="action">実行する処理</param>
        /// <returns>コレクション</returns>
        public static IEnumerable<T> Do<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (action == null)     throw new ArgumentNullException(nameof(action));
            return collection.DoCore(action);
        }


        /// <summary>
        /// Doメソッドの実処理を提供します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <param name="action">実行する処理</param>
        /// <returns>コレクション</returns>
        private static IEnumerable<T> DoCore<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
                yield return item;
            }
        }
        #endregion


        #region Convert
        /// <summary>
        /// 指定のコンバータを利用して非ジェネリックコレクションをジェネリックコレクションに変換します。
        /// </summary>
        /// <typeparam name="T">変換後の要素の型</typeparam>
        /// <param name="collection">変換元コレクション</param>
        /// <param name="converter">型コンバータ</param>
        /// <returns>変換されたコレクション</returns>
        public static IEnumerable<T> Convert<T>(this IEnumerable collection, Func<object, T> converter)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (converter == null)  throw new ArgumentNullException(nameof(converter));
            return collection.ConvertCore(converter);
        }


        /// <summary>
        /// Convertメソッドの実処理を提供します。
        /// </summary>
        /// <typeparam name="T">変換後の要素の型</typeparam>
        /// <param name="collection">変換元コレクション</param>
        /// <param name="converter">型コンバータ</param>
        /// <returns>変換されたコレクション</returns>
        private static IEnumerable<T> ConvertCore<T>(this IEnumerable collection, Func<object, T> converter)
        {
            foreach (var item in collection)
                yield return converter(item);
        }
        #endregion


        #region Concat
        /// <summary>
        /// 指定されたコレクションに要素を連結します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="first">接続先コレクション</param>
        /// <param name="second">末尾に追加する要素</param>
        /// <returns>連結されたコレクション</returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, params T[] second)
        {
            if (first == null)	throw new ArgumentNullException(nameof(first));
            if (second == null)	throw new ArgumentNullException(nameof(second));
            return Enumerable.Concat(first, second);
        }
        #endregion


        #region Buffer
        /// <summary>
        /// 指定されたコレクションを指定の数ずつにまとめます。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">対象となるコレクション</param>
        /// <param name="count">まとめる数</param>
        /// <returns>まとめられたコレクション</returns>
        public static IEnumerable<IEnumerable<T>> Buffer<T>(this IEnumerable<T> collection, int count)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (count <= 0)         throw new ArgumentOutOfRangeException(nameof(count));
            return collection.BufferCore(count);
        }


        /// <summary>
        /// Chunkメソッドの実処理を提供します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">対象となるコレクション</param>
        /// <param name="count">まとめる数</param>
        /// <returns>まとめられたコレクション</returns>
        private static IEnumerable<IEnumerable<T>> BufferCore<T>(this IEnumerable<T> collection, int count)
        {
            var result = new List<T>(count);
            foreach (var item in collection)
            {
                result.Add(item);
                if (result.Count == count)
                {
                    yield return result;
                    result = new List<T>(count);
                }
            }
            if (result.Count != 0)
                yield return result.ToArray();
        }
        #endregion


        #region WithIndex
        /// <summary>
        /// 要素にインデックスを付与したコレクションに変換します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">変換前コレクション</param>
        /// <returns>要素とインデックスのペアを持つコレクション</returns>
        public static IEnumerable<IndexedItem<T>> WithIndex<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            return collection.Select((x, i) => new IndexedItem<T>(x, i));
        }
        #endregion


        #region Distinct
        /// <summary>
        /// 指定の比較セレクターを用いて指定のコレクションから重複を削除します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <typeparam name="TKey">比較する値の型</typeparam>
        /// <param name="collection">重複削除の対象コレクション</param>
        /// <param name="selector">比較セレクター</param>
        /// <returns>重複が取り除かれたコレクション</returns>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            return collection.Distinct(new CompareSelector<T, TKey>(selector));
        }
        #endregion


        #region Except
        /// <summary>
        /// 指定された比較セレクターを使用して値を比較することにより、2 つのシーケンスの差集合を生成します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <typeparam name="TKey">比較する値の型</typeparam>
        /// <param name="first">secondには含まれていないが、返される要素を含むコレクション</param>
        /// <param name="second">最初のシーケンスにも含まれ、返されたシーケンスからは削除される要素を含むコレクション</param>
        /// <param name="selector">比較セレクター</param>
        /// <returns>差集合</returns>
        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            return first.Except(second, new CompareSelector<T, TKey>(selector));
        }
        #endregion


        #region Materialize
        /// <summary>
        /// collectionが遅延状態の場合は実体化して返し、既に実体化されている場合はそのまま自身を返します。
        /// </summary>
        /// <param name="collection">対象コレクション</param>
        /// <param name="returnsEmptyIfNull">collectionがnull時に空のコレクションを返すかどうか</param>
        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> collection, bool returnsEmptyIfNull = true)
        {
            if (collection == null)
            {
                if (returnsEmptyIfNull)
                    return Enumerable.Empty<T>();
                throw new ArgumentNullException(nameof(collection));
            }
            return  collection is ICollection<T>         ? collection
                :   collection is IReadOnlyCollection<T> ? collection
                :   collection.ToArray();
        }
        #endregion


        #region Nullable
        /// <summary>
        /// 値型の要素を持つコレクションをnull許容型のコレクションに変換します。
        /// </summary>
        /// <typeparam name="T">値型の要素</typeparam>
        /// <param name="collection">コレクション</param>
        /// <returns>null許容型の要素を持つコレクション</returns>
        public static IEnumerable<T?> AsNullable<T>(this IEnumerable<T> collection)
            where T : struct
                => collection.Cast<T?>();
        #endregion


        #region Shuffle
        /// <summary>
        /// スレッド毎に一意なランダム生成子を利用してコレクション要素の並びをシャッフルします。
        /// </summary>
        /// <param name="collection">対象コレクション</param>
        /// <returns>シャッフルされたコレクション</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
            => collection.Shuffle(RandomProvider.ThreadRandom);


        /// <summary>
        /// 指定されたランダム生成子を利用してコレクション要素の並びをシャッフルします。
        /// </summary>
        /// <param name="collection">対象コレクション</param>
        /// <param name="random">シャッフルに使用するランダム生成子</param>
        /// <returns>シャッフルされたコレクション</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection, Random random)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (random == null)     throw new ArgumentNullException(nameof(random));
            return collection.OrderBy(_ => random.Next());
        }
        #endregion


        #region Sample
        /// <summary>
        /// 指定されたコレクションから指定個数の要素をランダムに抽出します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <param name="count">抽出する要素数</param>
        /// <returns>抽出した要素のコレクション</returns>
        /// <remarks>同じ要素が複数回抽出される場合があります。</remarks>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> collection, int count)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (count <= 0)         throw new ArgumentOutOfRangeException(nameof(count));
            return collection.SampleCore(count, RandomProvider.ThreadRandom);
        }


        /// <summary>
        /// 指定されたコレクションから指定個数の要素をランダムに抽出します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <param name="count">抽出する要素数</param>
        /// <param name="random">ランダム生成子</param>
        /// <returns>抽出した要素のコレクション</returns>
        /// <remarks>同じ要素が複数回抽出される場合があります。</remarks>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> collection, int count, Random random)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (count <= 0)         throw new ArgumentOutOfRangeException(nameof(count));
            if (random == null)     throw new ArgumentNullException(nameof(random));
            return collection.SampleCore(count, random);
        }


        /// <summary>
        /// 指定されたコレクションから指定個数の要素をランダムに抽出します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <param name="count">抽出する要素数</param>
        /// <param name="random">ランダム生成子</param>
        /// <returns>抽出した要素のコレクション</returns>
        /// <remarks>同じ要素が複数回抽出される場合があります。</remarks>
        private static IEnumerable<T> SampleCore<T>(this IEnumerable<T> collection, int count, Random random)
        {
            var list = (collection as IList<T>) ?? collection.ToList();
            if (list.Count == 0)
                yield break;

            for (int i = 0; i < count; i++)
            {
                var index = random.Next(0, list.Count);
                yield return list[index];
            }
        }


        /// <summary>
        /// コレクションの中から要素をひとつだけ取り出します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <returns>ランダムにサンプリングされた要素のコレクション</returns>
        public static T SampleOne<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            return collection.Sample(1).FirstOrDefault();
        }


        /// <summary>
        /// コレクションの中から要素をひとつだけ取り出します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <param name="random">ランダム生成子</param>
        /// <returns>ランダムにサンプリングされた要素のコレクション</returns>
        public static T SampleOne<T>(this IEnumerable<T> collection, Random random)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (random == null)     throw new ArgumentNullException(nameof(random));
            return collection.Sample(1, random).FirstOrDefault();
        }
        #endregion


        #region Pairwise
        /// <summary>
        /// 要素の前後の値をペアリングします。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <returns>ペアリングされたコレクション</returns>
        public static IEnumerable<OldNewPair<T>> Pairwise<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            return collection.Zip(collection.Skip(1), (x, y) => new OldNewPair<T>(x, y));
        }


        /// <summary>
        /// 要素の前後の値をペアリングし、別の結果に射影します。
        /// </summary>
        /// <typeparam name="T">コレクション要素の型</typeparam>
        /// <typeparam name="TResult">射影後の型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <param name="resultSelector">結果の射影方法</param>
        /// <returns>射影された要素のコレクション</returns>
        public static IEnumerable<TResult> Pairwise<T, TResult>(this IEnumerable<T> collection, Func<T, T, TResult> resultSelector)
        {
            if (collection == null)     throw new ArgumentNullException(nameof(collection));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return collection.Zip(collection.Skip(1), resultSelector);
        }
        #endregion


        #region ToObservableCollection
        /// <summary>
        /// ObservableCollection&lt;T&gt; に変換します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="collection">対象コレクション</param>
        /// <returns>ObservableCollection&lt;T&gt; インスタンス</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            return new ObservableCollection<T>(collection);
        }
        #endregion
    }
}