using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Services.Shared
{
    /// <summary>
    /// 既定の日付プロバイダー。
    /// システム日付を使用して対象の日付を提供します。
    /// </summary>
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// 現在日付を返します。
        /// </summary>
        /// <returns>現在日付</returns>
        public DateTime GetCurrentDate()
        {
            return DateTime.Today;
        }

        /// <summary>
        /// 現在日時を返します。
        /// </summary>
        /// <returns>現在日時</returns>
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
