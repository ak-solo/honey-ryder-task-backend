using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクID
    /// </summary>
    public record TaskId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskId"/> class.
        /// タスクIDを生成します。
        /// </summary>
        /// <param name="value">ULID形式の文字列を指定します。</param>
        public TaskId(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タスクID
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// タスクIDを新規採番します。
        /// </summary>
        /// <returns>
        /// 新しく採番したタスクIDを返します。
        /// </returns>
        public static TaskId NewId()
        {
            return new TaskId(value: NUlid.Ulid.NewUlid().ToString());
        }
    }
}
