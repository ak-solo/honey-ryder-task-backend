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
    }
}
