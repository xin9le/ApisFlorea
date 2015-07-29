using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApisFlorea.Library.Threading.Tasks;
using Newtonsoft.Json;



namespace ApisFlorea.Library.Net.Http
{
    /// <summary>
    /// System.Net.Http.HttpContentの拡張機能を提供します。
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// 非同期操作としてJSONにHTTPコンテンツをシリアル化します。
        /// </summary>
        /// <param name="content">HTTPコンテンツ</param>
        /// <returns>シリアル化処理</returns>
        public static async Task<object> ReadAsJsonAsync(this HttpContent content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var body = await content.ReadAsStringAsync().Stay();
            return JsonConvert.DeserializeObject(body);
        }


        /// <summary>
        /// 非同期操作としてJSONにHTTPコンテンツをシリアル化します。
        /// </summary>
        /// <typeparam name="T">シリアル化先の型</typeparam>
        /// <param name="content">HTTPコンテンツ</param>
        /// <returns>シリアル化処理</returns>
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var body = await content.ReadAsStringAsync().Stay();
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}