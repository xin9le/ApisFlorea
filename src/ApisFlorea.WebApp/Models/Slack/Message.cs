using System.Collections.Generic;
using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Models.Slack
{
    /// <summary>
    /// Slack のメッセージを表します。
    /// </summary>
    public class Message
    {
        #region プロパティ
        /// <summary>
        /// ユーザー名を取得または設定します。
        /// </summary>
        /// <remarks>SlashCommands のときは利用しません</remarks>
        [JsonProperty("username")]
        public string UserName { get; set; }


        /// <summary>
        /// テキストを取得または設定します。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }


        /// <summary>
        /// 投稿先チャンネルを取得または設定します。
        /// </summary>
        /// <remarks>SlashCommands のときは利用しません</remarks>
        [JsonProperty("channel")]
        public string Channel { get; set; }


        /// <summary>
        /// 添付情報を取得または設定します。
        /// </summary>
        [JsonProperty("attachments")]
        public IReadOnlyCollection<Attachment> Attachments { get; set; }


        /// <summary>
        /// 応答方法を取得します。
        /// </summary>
        [JsonProperty("response_type")]
        public string ResponseType
            => this.IsEphemeral ? "ephemeral" : "in_channel";


        /// <summary>
        /// Markdown が含まれるプロパティの一覧を取得します。
        /// </summary>
        [JsonProperty("mrkdwn")]
        public bool IsMarkdown { get; set; }


        /// <summary>
        /// 自分のみに見えるメッセージにするかどうかを取得または設定します。
        /// </summary>
        [JsonIgnore]
        public bool IsEphemeral { get; set; }
        #endregion
    }
}