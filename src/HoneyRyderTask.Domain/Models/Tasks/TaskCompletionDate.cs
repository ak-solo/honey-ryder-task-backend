using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク完了日
    /// </summary>
    public record TaskCompletionDate
    {
        private TaskCompletionDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク完了日
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// タスク完了日を生成します。
        /// </summary>
        /// <param name="value">タスク完了日となる値を指定します。</param>
        /// <returns>
        /// 生成したタスク完了日を返します。
        /// </returns>
        public static TaskCompletionDate Create(DateTime value)
        {
            return new TaskCompletionDate(value);
        }

        /// <summary>
        /// タスク完了日を生成します。
        /// </summary>
        /// <param name="value">タスク完了日となる値を指定します。</param>
        /// <returns>
        /// 生成したタスク完了日を返します。
        /// </returns>
        public static TaskCompletionDate? CreateNullable(DateTime? value)
        {
            if (value == null) return null;
            return Create(value.GetValueOrDefault());
        }

        /// <summary>
        /// 現在日付でタスク完了日を生成します。
        /// </summary>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        /// <returns>タスク完了日</returns>
        public static TaskCompletionDate CreateWithCurrentDate(IDateTimeProvider dateTimeProvider)
        {
            return new TaskCompletionDate(dateTimeProvider.GetCurrentDate());
        }
    }
}
