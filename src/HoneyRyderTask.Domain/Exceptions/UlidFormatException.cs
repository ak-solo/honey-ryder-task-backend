namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// 指定の値がULID形式でない場合にスローされる例外。
    /// </summary>
    public class UlidFormatException : ExceptionBase
    {
        private const string ErrorMessage = "指定の値はULID形式ではありません。";

        /// <summary>
        /// 指定の値がULID形式でない場合にスローします。
        /// </summary>
        public UlidFormatException()
            : base(message: ErrorMessage)
        {
        }

        /// <summary>
        /// 指定の値がULID形式でない場合にスローします。
        /// </summary>
        /// <param name="innerException">内部例外</param>
        public UlidFormatException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }

        /// <summary>
        /// エラーコード
        /// </summary>
        public override ErrorCode ErrorCode => ErrorCode.UlidFormatException;
    }
}
