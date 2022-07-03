using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク作成日
    /// </summary>
    public record TaskCreatedDate
    {
        /// <summary>
        /// タスク作成日を生成します。
        /// </summary>
        /// <param name="value">タスク作成日となる値を指定します。</param>
        public TaskCreatedDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク作成日
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// 現在日付でタスク作成日を生成します。
        /// </summary>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        /// <returns>タスク作成日</returns>
        public static TaskCreatedDate CreateWithCurrentDate(IDateTimeProvider dateTimeProvider)
        {
            return new TaskCreatedDate(dateTimeProvider.GetCurrentDate());
        }
    }
}
