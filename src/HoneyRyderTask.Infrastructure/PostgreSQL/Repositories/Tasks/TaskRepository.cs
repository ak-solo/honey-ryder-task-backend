using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Infrastructure.PostgreSQL.DataModels.Tasks;
using TaskStatus = HoneyRyderTask.Domain.Models.Tasks.TaskStatus;

namespace HoneyRyderTask.Infrastructure.PostgreSQL.Repositories.Tasks
{
    /// <summary>
    /// タスクリポジトリ
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly HoneyRyderTaskDbContext context;

        /// <summary>
        /// タスクリポジトリを生成します。
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public TaskRepository(HoneyRyderTaskDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// タスクをリポジトリに追加します。
        /// </summary>
        /// <param name="task">タスク</param>
        public void Add(Domain.Models.Tasks.Task task)
        {
            var data = ToDataModel(task);
            this.context.Add(data);
            this.context.SaveChanges();
        }

        private static TaskDataModel ToDataModel(Domain.Models.Tasks.Task task)
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
