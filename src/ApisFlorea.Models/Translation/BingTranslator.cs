using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApisFlorea.Library.Net.Http;
using Newtonsoft.Json;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// Bing翻訳を利用した翻訳機能を提供します。
    /// </summary>
    public class BingTranslator : Translator
    {
        #region 内部クラス
        /// <summary>
        /// 送信用のパラメーターを表します。
        /// </summary>
        private class Parameter
        {
            public string id { get; set; }
            public string text { get; set; }
        }


        /// <summary>
        /// 翻訳結果を表します。
        /// </summary>
        private class Result
        {
            public string from { get; set; }
            public string to { get; set; }            
            public Item[] items { get; set; }
        }


        /// <summary>
        /// 翻訳結果のレコードを表します。
        /// </summary>
        private class Item
        {
            public string id { get; set; }
            public string text { get; set; }
            public string wordAlignment { get; set; }
        }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public BingTranslator()
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

            //--- データ生成 (配列にしなきゃダメ)
            var data = JsonConvert.SerializeObject(new []{ new Parameter { text = text } });
            using (var content = new StringContent(data, Encoding.UTF8, "application/json"))
            {
                //--- 一度アクセスして Cookie を読み込む
                var client = new HttpClient();
                await client.GetAsync("http://www.bing.com/translator/");

                //--- 言語指定は短い言語名で (ja/en/fr/etc.)
                //--- 自動判定はハイフン (from=-)
                //--- 例 : ?from=-&to=ja
                var fromName = from?.BingShortName ?? "-";
                var uri = Uri.EscapeUriString($"http://www.bing.com/translator/api/Translate/TranslateArray?from={fromName}&to={to.BingShortName}");
                var response = await client.PostAsync(uri, content);

                //--- 結果生成
                var result = await response.Content.ReadAsJsonAsync<Result>();
                return new TranslationResult
                (
                    Language.ByBingShortName[result.from],
                    to,
                    text,
                    result.items[0].text
                );
            }
        }
        #endregion
    }
}