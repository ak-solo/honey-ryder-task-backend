using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using Task = HoneyRyderTask.Domain.Models.Tasks.Task;

namespace HoneyRyderTask.Domain.Services.Tasks
{
    /// <summary>
    /// タスクファクトリ
    /// </summary>
    public class TaskFactory : ITaskFactory
    {
        private readonly IDateTimeProvider dateTimeProvider;

        /// <summary>
        /// タスクファクトリを生成します。
        /// </summary>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        public TaskFactory(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// タスクを作成します。
        /// </summary>
        /// <param name="param">タスク作成パラメタ</param>
        /// <returns>タスク</returns>
        public Task Create(TaskCreateParam param)
        {
            var title = TaskTitle.Create(param.Title);
            var description = TaskDescription.Create(param.Description);
            var dueDate = param.DueDate != null
                ? new TaskDueDate(param.DueDate.Value)
                : null;
            return Task.Create(title, description, dueDate, this.dateTimeProvider);
        }
    }
}
