using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク完了日
    /// </summary>
    public record TaskCompletedDate
    {
        /// <summary>
        /// タスク完了日を生成します。
        /// </summary>
        /// <param name="value">タスク完了日となる値を指定します。</param>
        public TaskCompletedDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク完了日
        /// </summary>
        public DateTime Value { get; }
    }
}
