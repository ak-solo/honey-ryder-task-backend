namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク完了日
    /// </summary>
    public record TaskCompletionDate
    {
        /// <summary>
        /// タスク完了日を生成します。
        /// </summary>
        /// <param name="value">タスク完了日となる値を指定します。</param>
        public TaskCompletionDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク完了日
        /// </summary>
        public DateTime Value { get; }
    }
}
