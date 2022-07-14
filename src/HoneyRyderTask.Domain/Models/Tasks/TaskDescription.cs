using HoneyRyderTask.Domain.Exceptions;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク説明
    /// </summary>
    public record TaskDescription
    {
        /// <summary>
        /// タスク説明の最大文字数
        /// </summary>
        public const int MaxLength = 1000;

        private TaskDescription(string value)
        {
            Validate(value);
            this.Value = value;
        }

        /// <summary>
        /// タスク説明
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 指定の値でタスク説明を生成します。
        /// </summary>
        /// <param name="value">タスク説明となる文字列を指定します。</param>
        /// <returns>
        /// 生成したタスク説明を返します。
        /// </returns>
        public static TaskDescription Create(string value)
        {
            return new TaskDescription(value);
        }

        /// <summary>
        /// 値を検証します。
        /// </summary>
        /// <param name="value">値</param>
        private static void Validate(string value)
        {
            if (value.Length > MaxLength) throw new MaxLengthException(MaxLength);
        }
    }
}
