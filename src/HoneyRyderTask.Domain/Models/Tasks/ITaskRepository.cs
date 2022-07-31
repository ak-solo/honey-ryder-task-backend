using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクリポジトリ
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// リポジトリからタスクIDに該当するタスクを取得します。
        /// </summary>
        /// <param name="taskId">タスクID</param>
        /// <returns>タスクIDに該当するタスクを返します。</returns>
        Task? Find(TaskId taskId);

        /// <summary>
        /// タスクをリポジトリに追加します。
        /// </summary>
        /// <param name="task">タスク</param>
        void Add(Task task);

        /// <summary>
        /// リポジトリのタスクを更新します。
        /// </summary>
        /// <param name="task">タスク</param>
        void Update(Task task);
    }
}
