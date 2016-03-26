using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApisFlorea.Core.Net.Http;
using Newtonsoft.Json.Linq;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// Google翻訳を利用した翻訳機能を提供します。
    /// </summary>
    public class GoogleTranslator : Translator
    {
        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public GoogleTranslator()
        {}
        #endregion


        #region オーバーライド
        /// <summary>
        /// 指定された言語から指定された言語に翻訳します。
        /// </summary>
        /// <param name="from">翻訳元の言語。nullの場合は言語を自動判定します。</param>
        /// <param name="to">翻訳先の言語</param>
        /// <param name="text">翻訳したい文章</param>
        /// <returns>翻訳結果</returns>
        public override async Task<TranslationResult> TranslateAsync(Language from, Language to, string text)
        {
            if (to == null)   throw new ArgumentNullException(nameof(to));
            if (text == null) throw new ArgumentNullException(nameof(text));

            //--- 言語指定は短い言語名で (ja/en/fr/etc.)
            //--- 自動判定はハイフン (from=auto)
            var code = from?.Code ?? "auto";
            var escaped = Uri.EscapeDataString(text);
            var uri = $"http://translate.google.co.jp/translate_a/single?client=t&sl={code}&tl={to.Code}&dt=t&tk=&ie=UTF-8&oe=UTF-8&q={escaped}";
            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var json = (await response.Content.ReadAsJsonAsync()) as JArray;

            //--- 結果生成
            return new TranslationResult
            (
                Language.ByCode[json.ElementAt(2).ToString()],
                to,
                text,
                json.First.First.First.ToString()
            );
        }
        #endregion
    }
}