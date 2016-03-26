using System;
using System.Net;



namespace ApisFlorea.Core.Net.Http
{
    /// <summary>
    /// HTTP応答時に発生した例外を表します。
    /// </summary>
    public class HttpResponseException : Exception
    {
        #region プロパティ
        /// <summary>
        /// ステータスコードを取得します。
        /// </summary>
        public HttpStatusCode StatusCode{ get; private set; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// ステータスコードを指定してインスタンスを生成します。
        /// </summary>
        /// <param name="statusCode">ステータスコード</param>
        public HttpResponseException(HttpStatusCode statusCode)
            : this(statusCode, null)
        {}


        /// <summary>
        /// ステータスコードと例外メッセージを指定してインスタンスを生成します。
        /// </summary>
        /// <param name="statusCode">ステータスコード</param>
        /// <param name="message">例外メッセージ</param>
        public HttpResponseException(HttpStatusCode statusCode, string message)
            : this(statusCode, message, null)
        {}


        /// <summary>
        /// 発生した例外を内部に保持し、ステータスコードと例外メッセージを指定してインスタンスを生成します。
        /// </summary>
        /// <param name="statusCode">ステータスコード</param>
        /// <param name="message">例外メッセージ</param>
        /// <param name="inner">内部例外</param>
        public HttpResponseException(HttpStatusCode statusCode, string message, Exception inner)
            : base(message, inner)
        {
            this.StatusCode = statusCode;
        }
        #endregion
    }
}