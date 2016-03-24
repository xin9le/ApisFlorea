using System.Threading.Tasks;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// 翻訳機能を提供します。
    /// </summary>
    public abstract class Translator
    {
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
    }
}