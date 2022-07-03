using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク期限
    /// </summary>
    public class TaskDueDate
    {
        /// <summary>
        /// タスク期限を生成します。
        /// </summary>
        /// <param name="value">タスク期限となる値を指定します。</param>
        public TaskDueDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク期限
        /// </summary>
        public DateTime Value { get; }
    }
}
