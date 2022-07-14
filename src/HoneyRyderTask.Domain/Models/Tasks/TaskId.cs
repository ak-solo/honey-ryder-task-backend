using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクID
    /// </summary>
    public record TaskId
    {
        /// <summary>
        /// タスクIDの最大文字数
        /// </summary>
        public const int MaxLengh = 26;

        private TaskId(string value)
        {
            Validate(value);
            this.Value = value;
        }

        /// <summary>
        /// タスクID
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// タスクIDを生成します。
        /// </summary>
        /// <param name="value">ULID形式の文字列を指定します。</param>
        /// <returns>
        /// 生成したタスクIDを返します。
        /// </returns>
        public static TaskId Create(string value)
        {
            return new TaskId(value);
        }

        /// <summary>
        /// タスクIDを新規採番します。
        /// </summary>
        /// <returns>
        /// 新しく採番したタスクIDを返します。
        /// </returns>
        public static TaskId NewId()
        {
            return new TaskId(value: ULID.NewULID().Value);
        }

        /// <summary>
        /// 値を検証します。
        /// </summary>
        private static void Validate(string value)
        {
            if (!ULID.IsULID(value)) throw new UlidFormatException();
        }
    }
}
