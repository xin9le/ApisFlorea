namespace ApisFlorea.Core.Linq
{
    /// <summary>
    /// 古い値と新しい値のペアを表します。
    /// </summary>
    /// <typeparam name="T">要素の型</typeparam>
    public struct OldNewPair<T>
    {
        #region プロパティ
        /// <summary>
        /// 古い値を取得します。
        /// </summary>
        public T Old { get; }


        /// <summary>
        /// 新しい値を取得します。
        /// </summary>
        public T New { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="old">古い値</param>
        /// <param name="new">新しい値</param>
        internal OldNewPair(T old, T @new)
        {
            this.Old = old;
            this.New = @new;
        }
        #endregion


        #region オーバーライド
        /// <summary>
        /// インスタンスを文字列化します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString() => $"({this.Old}, {this.New})";
        #endregion
    }
}