using HoneyRyderTask.Domain.Exceptions;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク説明
    /// </summary>
    public class TaskDescription
    {
        /// <summary>
        /// タスク説明の最大文字数
        /// </summary>
        public const int MaxLength = 1000;

        /// <summary>
        /// 指定の値でタスク説明を生成します。
        /// </summary>
        /// <param name="value">タスク説明となる文字列を指定します。</param>
        public TaskDescription(string value)
        {
            Validate(value);
            this.Value = value;
        }

        /// <summary>
        /// タスク説明
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 値を検証します。
        /// </summary>
        /// <param name="value">値</param>
        private void Validate(string value)
        {
            if (value.Length > MaxLength) throw new MaxLengthException(MaxLength);
        }
    }
}

