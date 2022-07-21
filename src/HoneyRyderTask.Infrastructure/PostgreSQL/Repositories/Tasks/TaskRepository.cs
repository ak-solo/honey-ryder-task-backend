using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Infrastructure.PostgreSQL.DataModels.Tasks;
using Task = HoneyRyderTask.Domain.Models.Tasks.Task;
using TaskStatus = HoneyRyderTask.Domain.Models.Tasks.TaskStatus;

namespace HoneyRyderTask.Infrastructure.PostgreSQL.Repositories.Tasks
{
    /// <summary>
    /// タスクリポジトリ
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly HoneyRyderTaskDbContext context;
        private readonly IDateTimeProvider dateTimeProvider;

        /// <summary>
        /// タスクリポジトリを生成します。
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        public TaskRepository(
            HoneyRyderTaskDbContext context,
            IDateTimeProvider dateTimeProvider)
        {
            this.context = context;
            this.dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// リポジトリからタスクIDに該当するタスクを取得します。
        /// </summary>
        /// <param name="taskId">タスクID</param>
        /// <returns>タスクIDに該当するタスクを返します。</returns>
        public Task? Find(TaskId taskId)
        {
            var data = this.context.Tasks.Find(taskId.Value);
            if (data == null) return null;
            return ToDomainModel(data, this.dateTimeProvider);
        }

        /// <summary>
        /// タスクをリポジトリに追加します。
        /// </summary>
        /// <param name="task">タスク</param>
        public void Add(Task task)
        {
            var data = ToDataModel(task);
            this.context.Add(data);
            this.context.SaveChanges();
        }

        private static Task ToDomainModel(TaskDataModel data, IDateTimeProvider dateTimeProvider)
        {
            return Task.Reconstruct(
                id: TaskId.Create(data.TaskId),
                title: TaskTitle.Create(data.Title),
                description: TaskDescription.Create(data.Description),
                status: TaskStatus.ValueOf(data.Status),
                dueDate: TaskDueDate.CreateNullable(data.DueDate),
                creationDate: TaskCreationDate.Create(data.CreationDate),
                completionDate: TaskCompletionDate.CreateNullable(data.CompletionDate),
                dateTimeProvider: dateTimeProvider);
        }

        private static TaskDataModel ToDataModel(Task task)
        {
            return new TaskDataModel()
            {
                TaskId = task.Id.Value,
                Title = task.Title.Value,
                Description = task.Description.Value,
                Status = task.Status.Value,
                DueDate = task.DueDate?.Value,
                CreationDate = task.CreationDate.Value,
                CompletionDate = task.CompletionDate?.Value,
            };
        }
    }
}
