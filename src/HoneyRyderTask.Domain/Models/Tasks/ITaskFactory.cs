using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクファクトリ
    /// </summary>
    public interface ITaskFactory
    {
        /// <summary>
        /// タスクを作成します。
        /// </summary>
        /// <param name="param">タスク作成パラメータ</param>
        /// <returns>タスク</returns>
        Task Create(TaskCreateParam param);
    }
}
