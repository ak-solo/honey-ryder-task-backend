using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク作成日
    /// </summary>
    public record TaskCreationDate
    {
        /// <summary>
        /// タスク作成日を生成します。
        /// </summary>
        /// <param name="value">タスク作成日となる値を指定します。</param>
        private TaskCreationDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク作成日
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// タスク作成日を生成します。
        /// </summary>
        /// <param name="value">タスク作成日となる値を指定します。</param>
        /// <returns>
        /// 生成されたタスク作成日を返します。
        /// </returns>
        public static TaskCreationDate ValueOf(DateTime value)
        {
            return new TaskCreationDate(value);
        }

        /// <summary>
        /// 現在日付でタスク作成日を生成します。
        /// </summary>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        /// <returns>タスク作成日</returns>
        public static TaskCreationDate CreateWithCurrentDate(IDateTimeProvider dateTimeProvider)
        {
            return new TaskCreationDate(dateTimeProvider.GetCurrentDate());
        }
    }
}
