namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// エラーコード
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 指定の値がULID形式でない場合にスローされる例外。
        /// </summary>
        UlidFormatException = 1001,
    }
}
