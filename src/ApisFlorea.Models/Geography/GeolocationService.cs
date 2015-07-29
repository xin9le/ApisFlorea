using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApisFlorea.Library.Net.Http;
using ApisFlorea.Library.Threading.Tasks;



namespace ApisFlorea.Models.Geography
{
    /// <summary>
    /// 地理位置情報サービスを提供します。
    /// </summary>
    public static class GeolocationService
    {
        /// <summary>
        /// 指定された住所から緯度経度座標を取得します。
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns>座標情報</returns>
        public static async Task<Coordinate> GeocodingAsync(string address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            var data = string.Format("address={0}", address);
            using (var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded"))
            {
                var url = "http://www13.info-mapping.com/uq/btmap/services/gcs.aspx";
                var client = new HttpClient();
                var response = await client.PostAsync(url, content).Stay();
                response.ThrowIfError();

                dynamic json = await response.Content.ReadAsJsonAsync().Stay();
                if (bool.Parse((string)json.error))
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
/*
                const int searchableLevel = 61;
                var level = int.Parse((string)json.result.level);
                if (level < searchableLevel)
                    throw new HttpResponseException(HttpStatusCode.Forbidden);
*/
                var x = decimal.Parse((string)json.result.x);
                var y = decimal.Parse((string)json.result.y);
                return new Coordinate(y, x);
            }
        }
    }
}