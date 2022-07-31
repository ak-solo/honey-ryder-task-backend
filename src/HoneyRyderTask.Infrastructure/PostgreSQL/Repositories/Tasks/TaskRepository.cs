using System.Net.NetworkInformation;
using System.Threading.Tasks;
using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Infrastructure.PostgreSQL.DataModels.Tasks;
using Microsoft.VisualBasic;
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

        /// <summary>
        /// リポジトリのタスクを更新します。
        /// </summary>
        /// <param name="task">タスク</param>
        public void Update(Task task)
        {
            var data = this.context.Tasks.Find(task.Id.Value);
            if (data == null) throw new DataNotFoundException(nameof(Task));
            Transfer(task, ref data);
            this.context.SaveChanges();
        }

        private static Task ToDomainModel(TaskDataModel data, IDateTimeProvider dateTimeProvider)
        {
            return Task.Reconstruct(
                id: TaskId.ValueOf(data.TaskId),
                title: TaskTitle.ValueOf(data.Title),
                description: TaskDescription.ValueOf(data.Description),
                status: TaskStatus.ValueOf(data.Status),
                dueDate: TaskDueDate.NullableValueOf(data.DueDate),
                creationDate: TaskCreationDate.ValueOf(data.CreationDate),
                completionDate: TaskCompletionDate.NullableValueOf(data.CompletionDate),
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

        private static void Transfer(Task task, ref TaskDataModel data)
        {
            data.TaskId = task.Id.Value;
            data.Title = task.Title.Value;
            data.Description = task.Description.Value;
            data.Status = task.Status.Value;
            data.DueDate = task.DueDate?.Value;
            data.CreationDate = task.CreationDate.Value;
            data.CompletionDate = task.CompletionDate?.Value;
        }
    }
}
