using System;
using System.Collections.Generic;



namespace ApisFlorea.Core.Linq
{
    /// <summary>
    /// デリゲートで外部から等値比較方法を指定する、比較セレクターとしての機能を提供ます。
    /// </summary>
    /// <typeparam name="T">オブジェクトの型</typeparam>
    /// <typeparam name="TKey">比較する値の型</typeparam>
    internal sealed class CompareSelector<T, TKey> : IEqualityComparer<T>
    {
        #region プロパティ
        /// <summary>
        /// 比較するためのセレクターを取得します。
        /// </summary>
        private Func<T, TKey> Selector { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// 指定のセレクターからインスタンスを生成します。
        /// </summary>
        /// <param name="selector">比較用セレクター</param>
        public CompareSelector(Func<T, TKey> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            this.Selector = selector;
        }
        #endregion


        #region IEqualityComparer<T>の実装
        /// <summary>
        /// 指定したオブジェクトが等しいかどうかを判断します。
        /// </summary>
        /// <param name="x">比較対象のT型の第1オブジェクト</param>
        /// <param name="y">比較対象のT型の第2オブジェクト</param>
        /// <returns>等しいかどうか</returns>
        public bool Equals(T x, T y)
        {
            if (this.Selector(x) == null)
            if (this.Selector(y) == null)   return true;
            if (this.Selector(x) == null)   return false;
            if (this.Selector(y) == null)   return false;
            return this.Selector(x).Equals(this.Selector(y));
        }


        /// <summary>
        /// 指定したオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <param name="obj">ハッシュコードが返される対象のオブジェクト</param>
        /// <returns>ハッシュコード</returns>
        public int GetHashCode(T obj)
        {
            return  this.Selector(obj) == null
                ?   default(int)
                :   this.Selector(obj).GetHashCode();
        }
        #endregion
    }
}