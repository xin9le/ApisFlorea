namespace ApisFlorea.Models.ServiceArea.UqWimax
{
    /// <summary>
    /// UQ WiMAXのサービスレベルを表します。
    /// </summary>
    public enum ServiceLevel
    {
        /// <summary>
        /// 圏外
        /// </summary>
        OutOfService = 0,

        /// <summary>
        /// 非常に良い
        /// </summary>
        Excellent = 1,

        /// <summary>
        /// 良い
        /// </summary>
        Good = 2,

        /// <summary>
        /// 悪い
        /// </summary>
        Bad = 3,
    }
}