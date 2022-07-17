namespace HoneyRyderTask.Domain.Exceptions
{
    /// <summary>
    /// データ見つからない場合にスローされる例外。
    /// </summary>
    public class DataNotFoundException : ExceptionBase
    {
        private const string ErrorMessage = "{0}が見つかりません。";

        /// <summary>
        /// データ見つからない場合にスローします。
        /// </summary>
        /// <param name="dataName">データ名</param>
        public DataNotFoundException(string dataName)
            : base(message: string.Format(ErrorMessage, dataName))
        {
            this.DataName = dataName;
        }

        /// <summary>
        /// データ見つからない場合にスローします。
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="innerException">内部例外</param>
        public DataNotFoundException(string dataName, Exception innerException)
            : base(message: string.Format(ErrorMessage, dataName), innerException)
        {
            this.DataName = dataName;
        }

        /// <summary>
        /// データ名
        /// </summary>
        public string DataName { get; }

        /// <summary>
        /// エラーコード
        /// </summary>
        public override ErrorCode ErrorCode => ErrorCode.DataNotFoundException;
    }
}
