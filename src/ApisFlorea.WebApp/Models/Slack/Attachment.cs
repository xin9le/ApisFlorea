using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Models.Slack
{
    /// <summary>
    /// メッセージの添付情報を表します。
    /// </summary>
    public class Attachment
    {
        #region プロパティ
        /// <summary>
        /// 色を取得または設定します。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }


        /// <summary>
        /// 添付情報の前に表示するテキストを取得または設定します。
        /// </summary>
        [JsonProperty("pretext")]
        public string PreText { get; set; }


        /// <summary>
        /// 著者名を取得または設定します。
        /// </summary>
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }


        /// <summary>
        /// 著者のリンクを取得または設定します。
        /// </summary>
        [JsonProperty("author_link")]
        public string AuthorLink { get; set; }


        /// <summary>
        /// 著者アイコンの URL を取得または設定します。
        /// </summary>
        [JsonProperty("author_icon")]
        public string AuthorIcon { get; set; }


        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }


        /// <summary>
        /// タイトルのリンクを取得または設定します。
        /// </summary>
        [JsonProperty("title_link")]
        public string TitleLink { get; set; }


        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }


        /// <summary>
        /// 画像 URL を取得または設定します。
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }


        /// <summary>
        /// サムネイル画像 URL を取得または設定します。
        /// </summary>
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }


        /// <summary>
        /// 添付情報を表示できない場合のテキストを取得または設定します。
        /// </summary>
        [JsonProperty("fallback")]
        public string Fallback { get; set; }


        /// <summary>
        /// フィールドのコレクションを取得または設定します。
        /// </summary>
        [JsonProperty("fields")]
        public IReadOnlyCollection<Field> Fields { get; set; }


        /// <summary>
        /// Markdown が含まれるプロパティの一覧を取得します。
        /// </summary>
        [JsonProperty("mrkdwn_in")]
        public IReadOnlyCollection<string> MarkdownIn
        {
            get
            {
                var result = new List<string>();
                if (this.IsMarkdownInPreText)   result.Add("pretext");
                if (this.IsMarkdownInText)      result.Add("text");
                return result.Any() ? result : null;
            }
        }


        /// <summary>
        /// PreText プロパティに Markdown が含まれるかどうかを取得または設定します。
        /// </summary>
        [JsonIgnore]
        public bool IsMarkdownInPreText { get; set; }


        /// <summary>
        /// Text プロパティに Markdown が含まれるかどうかを取得または設定します。
        /// </summary>
        [JsonIgnore]
        public bool IsMarkdownInText { get; set; }
        #endregion
    }
}