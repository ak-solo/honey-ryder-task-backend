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

        private TaskTitle(string value)
        {
            Validate(value);
            this.Value = value;
        }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// タスクタイトルを生成します。
        /// </summary>
        /// <param name="value">タスクタイトルとなる文字列を指定します。</param>
        /// <returns>
        /// 生成したタスクタイトルを返します。
        /// </returns>
        public static TaskTitle ValueOf(string value)
        {
            return new TaskTitle(value);
        }

        /// <summary>
        /// 値を検証します。
        /// </summary>
        /// <param name="value">値</param>
        private static void Validate(string value)
        {
            if (value.Length > MaxLengh) throw new MaxLengthException(MaxLengh);
        }
    }
}
