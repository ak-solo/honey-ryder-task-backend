namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク状態
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// 未着手
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// 着手
        /// </summary>
        Started = 1,

        /// <summary>
        /// 完了
        /// </summary>
        Completed = 2,
    }
}
