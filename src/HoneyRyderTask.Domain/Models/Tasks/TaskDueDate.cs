using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク期限
    /// </summary>
    public record TaskDueDate
    {
        private TaskDueDate(DateTime value)
        {
            this.Value = value.Date;
        }

        /// <summary>
        /// タスク期限
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// タスク期限を生成します。
        /// </summary>
        /// <param name="value">タスク期限となる値を指定します。</param>
        /// <returns>
        /// 生成したタスク期限を返します。
        /// </returns>
        public static TaskDueDate ValueOf(DateTime value)
        {
            return new TaskDueDate(value);
        }

        /// <summary>
        /// タスク期限を生成します。
        /// </summary>
        /// <param name="value">タスク期限となる値を指定します。</param>
        /// <returns>
        /// 生成したタスク期限を返します。
        /// </returns>
        public static TaskDueDate? NullableValueOf(DateTime? value)
        {
            if (value == null) return null;
            return ValueOf(value.GetValueOrDefault());
        }
    }
}
