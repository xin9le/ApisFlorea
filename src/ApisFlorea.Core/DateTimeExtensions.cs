using System;



namespace ApisFlorea.Core
{
    /// <summary>
    /// DateTimeの拡張機能を提供します。
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 指定された日の終わりを返します。
        /// </summary>
        /// <param name="value">日</param>
        /// <returns>日の終わりの時刻</returns>
        public static DateTime EndOfDay(this DateTime value)
            => value.Date.AddDays(1).AddTicks(-1);


        /// <summary>
        /// 指定された日付がふたつの日時の間かどうかを返します。
        /// </summary>
        /// <param name="value">対象日時</param>
        /// <param name="from">開始日時</param>
        /// <param name="to">終了日時</param>
        /// <returns>間かどうか</returns>
        public static bool InBetween(this DateTime value, DateTime from, DateTime to)
            => from <= value && value <= to;
    }
}