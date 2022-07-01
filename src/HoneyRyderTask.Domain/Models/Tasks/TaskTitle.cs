using HoneyRyderTask.Domain.Exceptions;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクタイトル
    /// </summary>
    public record TaskTitle
    {
        /// <summary>
        /// タスクタイトルの最大文字数
        /// </summary>
        public const int MaxLengh = 30;

        /// <summary>
        /// タスクタイトルを生成します。
        /// </summary>
        /// <param name="value">タスクタイトルとなる文字列を指定します。</param>
        public TaskTitle(string value)
        {
            this.Validate(value);
            this.Value = value;
        }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 値を検証します。
        /// </summary>
        private void Validate(string value)
        {
            if (value.Length > MaxLengh) throw new MaxLengthException(MaxLengh);
        }
    }
}
