using System;

namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// 例外クラス - base
    /// </summary>
    public abstract class ExceptionBase : Exception
    {
        /// <summary>
        /// 例外クラスを生成します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public ExceptionBase(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 例外クラスを生成します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="innerException">内部例外</param>
        public ExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// エラーコード
        /// </summary>
        public abstract ErrorCode ErrorCode { get; }
    }
}
