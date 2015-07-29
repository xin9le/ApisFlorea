namespace ApisFlorea.Models.Geography
{
    /// <summary>
    /// 座標情報を表します。
    /// </summary>
    public class Coordinate
    {
        #region プロパティ
        /// <summary>
        /// 緯度を取得します。
        /// </summary>
        public decimal Latitude { get; }


        /// <summary>
        /// 経度を取得します。
        /// </summary>
        public decimal Longitude { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// 指定された緯度経度情報を元にインスタンスを生成します。
        /// </summary>
        /// <param name="latitude">緯度</param>
        /// <param name="longitude">経度</param>
        public Coordinate(decimal latitude = 0, decimal longitude = 0)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        #endregion


        #region オーバーライド
        /// <summary>
        /// インスタンスを文字列化します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return $"{this.Latitude}, {this.Longitude}";
        }
        #endregion
    }
}