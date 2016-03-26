using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApisFlorea.Core.Net.Http;
using ApisFlorea.Core.Threading.Tasks;
using ApisFlorea.Models.Geography;



namespace ApisFlorea.Models.ServiceArea.UqWimax
{
    /// <summary>
    /// UQ WiMAXのサービスエリア判定を行う機能を提供します。
    /// </summary>
    public static class AreaChecker
    {
        /// <summary>
        /// 指定されたサービスが、指定された位置でどの程度のサービスレベルを提供しているかを確認します。
        /// </summary>
        /// <param name="service">サービスの種類</param>
        /// <param name="coord">座標情報</param>
        /// <returns>サービスレベル</returns>
        public static async Task<ServiceLevel> CheckAsync(ServiceKind service, Coordinate coord)
        {
            var url = string.Format
            (
                "http://www13.info-mapping.com/uq/btmap/services/getPinpoint.asp?tableid=A&layerno={0}&xcoord={1}&ycoord={2}",
                (int)service,
                coord.Longitude,
                coord.Latitude
            );
            var client = new HttpClient();
            var response = await client.GetAsync(url).Stay();
            response.ThrowIfError();

            var body = await response.Content.ReadAsStringAsync().Stay();
            var value = body.Trim().Replace("([", string.Empty).Replace("]);", string.Empty);
            return (ServiceLevel)Enum.Parse(typeof(ServiceLevel), value);
        }
    }
}