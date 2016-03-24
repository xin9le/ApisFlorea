using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Models.Slack
{
    /// <summary>
    /// SlashCommandsからのリクエストを表します。
    /// </summary>
    public class SlashCommandsRequest
    {
        #region プロパティ
        /// <summary>
        /// トークンを取得または設定します。
        /// </summary>
        [Required]
        [JsonProperty("token")]
        public string Token { get; set; }


        /// <summary>
        /// チームIDを取得または設定します。
        /// </summary>
        [JsonProperty("team_id")]
        public string TeamId { get; set; }


        /// <summary>
        /// チームドメインを取得または設定します。
        /// </summary>
        [JsonProperty("team_domain")]
        public string TeamDomain { get; set; }


        /// <summary>
        /// チャンネルIDを取得または設定します。
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }


        /// <summary>
        /// チャンネル名を取得または設定します。
        /// </summary>
        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }


        /// <summary>
        /// ユーザーIDを取得または設定します。
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }


        /// <summary>
        /// ユーザー名を取得または設定します。
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }


        /// <summary>
        /// コマンドを取得または設定します。
        /// </summary>
        [Required]
        [JsonProperty("command")]
        public string Command { get; set; }


        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }


        /// <summary>
        /// 応答URLを取得または設定します。
        /// </summary>
        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }
        #endregion
    }
}