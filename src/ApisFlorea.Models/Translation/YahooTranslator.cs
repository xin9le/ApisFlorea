using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// Yahoo!翻訳を利用した翻訳機能を提供します。
    /// </summary>
    public class YahooTranslator : Translator
    {
        #region プロパティ
        /// <summary>
        /// 名称を取得します。
        /// </summary>
        public override string Name => "Yahoo! 翻訳";


        /// <summary>
        /// テーマカラーを取得します。
        /// </summary>
        /// <remarks>HEX形式 : #337DF2</remarks>
        public override string ThemeColor => "#FF0031";


        /// <summary>
        /// サイト URL を取得します。
        /// </summary>
        public override string SiteUrl => "http://honyaku.yahoo.co.jp";


        /// <summary>
        /// アイコン URL を取得します。
        /// </summary>
        public override string IconUrl => "http://freesoft-100.com/img/yahoo-toolbar.png";
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public YahooTranslator()
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

            //--- 言語判定
            var client = new HttpClient();
            string fromCode = null;
            {
                var uri = Uri.EscapeUriString($"http://honyaku.yahoo.co.jp/LangClassifyService/V1/predict_prob?query={text}&output=json");
                var response = await client.GetAsync(uri);
                var bytes = await response.Content.ReadAsByteArrayAsync();
                var json = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                var obj = (JObject)JsonConvert.DeserializeObject(json);
                fromCode = obj["ResultSet"]["Predict"]["_content"].ToString();
            }

            //--- トークンの取得
            string token = null;
            {
                var html = await client.GetStringAsync("http://honyaku.yahoo.co.jp");
                var search = "name=\"TTcrumb\" value=\"";
                var start = html.IndexOf(search) + search.Length;
                var end = html.IndexOf("\"/>", start);
                token = html.Substring(start, end - start);
            }

            //--- 翻訳
            var form = new Dictionary<string, string>()
            {
                ["p"] =	text,
                ["ieid"] = fromCode,
                ["oeid"] = to.Code,
                ["results"] = "1000",
                ["formality"] = "0",
                ["_crumb"] = token,
                ["output"] = "json",
            };
            using (var content = new FormUrlEncodedContent(form))
            {
                var uri = "http://honyaku.yahoo.co.jp/TranslationText";
                var response = await client.PostAsync(uri, content);
                var json = await response.Content.ReadAsStringAsync();
                var obj = (JObject)JsonConvert.DeserializeObject(json);
                var results = obj["ResultSet"]["ResultText"]["Results"].Select(x => x["TranslatedText"]);
                var after = string.Join(Environment.NewLine, results);

                //--- 結果
                return new TranslationResult
                (
                    Language.ByCode[fromCode],
                    to,
                    text,
                    after
                );
            }
        }
        #endregion
    }
}