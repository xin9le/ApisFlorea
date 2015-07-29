using System.ComponentModel.DataAnnotations;
using ApisFlorea.Models.ServiceArea.UqWimax;



namespace ApisFlorea.WebApp.Models.ServiceArea
{
    /// <summary>
    /// UQ WiMAXのサービス提供エリア確認用パラメーターを表します。
    /// </summary>
    public class UqAreaCheckParameter
    {
        /// <summary>
        /// 提供サービスの種類を取得または設定します。
        /// </summary>
        [Required]
        public ServiceKind? Service { get; set; }


        /// <summary>
        /// 住所を取得または設定します。
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
