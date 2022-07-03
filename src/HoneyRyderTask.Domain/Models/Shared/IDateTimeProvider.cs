using System;

namespace HoneyRyderTask.Domain.Models.Shared
{
    /// <summary>
    /// 日付を提供します。
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// 現在日付を取得します。
        /// </summary>
        /// <returns>現在日付</returns>
        public DateTime GetCurrentDate();

        /// <summary>
        /// 現在日時を取得します。
        /// </summary>
        /// <returns>現在日時</returns>
        public DateTime GetCurrentDateTime();
    }
}
