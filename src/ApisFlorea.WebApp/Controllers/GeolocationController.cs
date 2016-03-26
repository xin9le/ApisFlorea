using System.Threading.Tasks;
using ApisFlorea.Core.Threading.Tasks;
using ApisFlorea.Models.Geography;
using Microsoft.AspNet.Mvc;



namespace ApisFlorea.WebApp.Controllers
{
    /// <summary>
    /// 地理位置情報に関する要求を処理します。
    /// </summary>
    public class GeolocationController : Controller
    {
        /// <summary>
        /// 指定された住所から緯度経度座標を取得します。
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns>結果</returns>
        [HttpGet]
        public async Task<IActionResult> Geocoding([FromQuery]string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return this.HttpBadRequest(address);

            var coord = await GeolocationService.GeocodingAsync(address).Stay();
            return this.Json(coord);
        }
    }
}