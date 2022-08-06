using System;

namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// 指定の値が最大文字数を超えている場合にスローされる例外。
    /// </summary>
    public class MaxLengthException : ExceptionBase
    {
        private const string ErrorMessage = "指定の値が最大文字数を超えています。（最大文字数:{0}文字）";

        /// <summary>
        /// 指定の値が最大文字数を超えている場合にスローします。
        /// </summary>
        /// <param name="maxLength">最大文字数</param>
        public MaxLengthException(int maxLength)
            : base(message: string.Format(ErrorMessage, maxLength))
        {
        }

        /// <summary>
        /// 指定の値が最大文字数を超えている場合にスローします。
        /// </summary>
        /// <param name="maxLength">最大文字数</param>
        /// <param name="innerException">内部例外</param>
        public MaxLengthException(int maxLength, Exception innerException)
            : base(message: string.Format(ErrorMessage, maxLength), innerException)
        {
        }

        /// <summary>
        /// エラーコード
        /// </summary>
        public override ErrorCode ErrorCode => ErrorCode.MaxLengthException;
    }
}
