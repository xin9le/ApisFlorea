using System.Threading.Tasks;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// 翻訳機能を提供します。
    /// </summary>
    public abstract class Translator
    {
        #region プロパティ
        /// <summary>
        /// 名称を取得します。
        /// </summary>
        public abstract string Name { get; }


        /// <summary>
        /// テーマカラーを取得します。
        /// </summary>
        /// <remarks>HEX形式 : #337DF2</remarks>
        public abstract string ThemeColor { get; }


        /// <summary>
        /// サイト URL を取得します。
        /// </summary>
        public abstract string SiteUrl { get; }


        /// <summary>
        /// アイコン URL を取得します。
        /// </summary>
        public abstract string IconUrl { get; }
        #endregion


        #region 翻訳
        /// <summary>
        /// 翻訳前の文章を自動判定して指定の言語に翻訳します。
        /// </summary>
        /// <param name="to">翻訳先の言語</param>
        /// <param name="text">翻訳したい文章</param>
        /// <returns>翻訳結果</returns>
        public Task<TranslationResult> TranslateAsync(Language to, string text)
            => this.TranslateAsync(null, to, text);


        /// <summary>
        /// 指定された言語から指定された言語に翻訳します。
        /// </summary>
        /// <param name="from">翻訳元の言語。nullの場合は言語を自動判定します。</param>
        /// <param name="to">翻訳先の言語</param>
        /// <param name="text">翻訳したい文章</param>
        /// <returns>翻訳結果</returns>
        public abstract Task<TranslationResult> TranslateAsync(Language from, Language to, string text);
        #endregion
    }
}