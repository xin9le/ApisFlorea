namespace ApisFlorea.Core.Linq
{
    /// <summary>
    /// 要素とインデックスのペアを表します。
    /// </summary>
    /// <typeparam name="T">格納する要素の型</typeparam>
    public struct IndexedItem<T>
    {
        #region プロパティ
        /// <summary>
        /// 要素を取得します。
        /// </summary>
        public T Element{ get; }


        /// <summary>
        /// インデックスを取得します。
        /// </summary>
        public int Index{ get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="element">要素</param>
        /// <param name="index">インデックス</param>
        internal IndexedItem(T element, int index)
        {
            this.Element = element;
            this.Index   = index;
        }
        #endregion


        #region オーバーライド
        /// <summary>
        /// インスタンスを文字列化します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString() => $"{{{this.Index}}}, {{{this.Element}}}";
        #endregion
    }
}