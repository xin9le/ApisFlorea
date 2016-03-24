using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Models.Slack
{
    /// <summary>
    /// 添付フィールドを表します。
    /// </summary>
    public class Field
    {
        #region プロパティ
        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }


        /// <summary>
        /// 値を取得または設定します。
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }


        /// <summary>
        /// 短く表示するかどうかを取得または設定します。
        /// </summary>
        [JsonProperty("short")]
        public bool IsShort { get; set; }
        #endregion
    }
}   