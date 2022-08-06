namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// エラーコード
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 指定の値が最大文字数を超えている場合にスローされる例外。
        /// </summary>
        MaxLengthException = 2,

        /// <summary>
        /// 指定の値がULID形式でない場合にスローされる例外。
        /// </summary>
        UlidFormatException = 1001,

        /// <summary>
        /// データ見つからない場合にスローされる例外。
        /// </summary>
        DataNotFoundException = 1002,
    }
}
