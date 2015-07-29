using System.Threading.Tasks;
using ApisFlorea.Library.Threading.Tasks;
using ApisFlorea.Models.Geography;
using ApisFlorea.Models.ServiceArea.UqWimax;
using ApisFlorea.WebApp.Models.ServiceArea;
using Microsoft.AspNet.Mvc;



namespace ApisFlorea.WebApp.Controllers
{
    /// <summary>
    /// サービス提供エリアに関する要求を処理します。
    /// </summary>
    public class ServiceAreaController : Controller
    {
        #region API
        /// <summary>
        /// UQ WiMAXの指定のサービスが指定の住所において提供するサービスの品質レベルを取得します。
        /// </summary>
        /// <param name="parameter">パラメーター</param>
        /// <returns>結果</returns>
        [HttpGet]
        public async Task<IActionResult> Uq([FromQuery]UqAreaCheckParameter parameter)
        {
            if (!this.ModelState.IsValid)
                return this.HttpBadRequest(this.ModelState);

            var coord = await GeolocationService.GeocodingAsync(parameter.Address).Stay();
            var level = await AreaChecker.CheckAsync(parameter.Service.Value, coord).Stay();
            return this.Json(level);
        }
        #endregion
    }
}