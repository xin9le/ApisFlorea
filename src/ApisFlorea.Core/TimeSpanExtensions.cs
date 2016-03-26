using System;



namespace ApisFlorea.Core
{
    /// <summary>
    /// TimeSpanの拡張機能を提供します。
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// 指定された時間間隔がふたつの時間間隔の間かどうかを返します。
        /// </summary>
        /// <param name="value">対象時間間隔</param>
        /// <param name="from">開始時間間隔</param>
        /// <param name="to">終了時間間隔</param>
        /// <returns>間かどうか</returns>
        public static bool InBetween(this TimeSpan value, TimeSpan from, TimeSpan to)
            => from <= value && value <= to;
    }
}