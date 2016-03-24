using System;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// 翻訳結果を表します。
    /// </summary>
    public class TranslationResult
    {
        #region プロパティ
        /// <summary>
        /// 翻訳元の言語を取得します。
        /// </summary>
        public Language From { get; }


        /// <summary>
        /// 翻訳先の言語を取得します。
        /// </summary>
        public Language To { get; }


        /// <summary>
        /// 翻訳前の文章を取得します。
        /// </summary>
        public string Before { get; }


        /// <summary>
        /// 翻訳先の文章を取得します。
        /// </summary>
        public string After { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="from">翻訳元の言語</param>
        /// <param name="to">翻訳先の言語</param>
        /// <param name="before">翻訳前の文章</param>
        /// <param name="after">翻訳語の文章</param>
        public TranslationResult(Language from, Language to, string before, string after)
        {
            if (from == null)   throw new ArgumentNullException(nameof(from));
            if (to == null)     throw new ArgumentNullException(nameof(to));
            if (before == null) throw new ArgumentNullException(nameof(before));
            if (after == null)  throw new ArgumentNullException(nameof(after));

            this.From = from;
            this.To = to;
            this.Before = before;
            this.After = after;
        }
        #endregion
    }
}