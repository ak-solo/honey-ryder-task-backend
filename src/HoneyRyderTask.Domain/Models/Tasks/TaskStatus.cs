using System.Reflection;
using HoneyRyderTask.Domain.Models.Shared;

#pragma warning disable SA1401

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク状態
    /// </summary>
    public record TaskStatus : TypeSafeEnum<TaskStatus>
    {
        /// <summary>
        /// 未着手
        /// </summary>
        public static TaskStatus NotStarted = new TaskStatus(value: 1);

        /// <summary>
        /// 着手
        /// </summary>
        public static TaskStatus Started = new TaskStatus(value: 2);

        /// <summary>
        /// 完了
        /// </summary>
        public static TaskStatus Completed = new TaskStatus(value: 3);

        private TaskStatus(int value)
            : base(value)
        {
        }
    }
}
