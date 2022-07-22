using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.UseCase.Attributes;
using Task = HoneyRyderTask.Domain.Models.Tasks.Task;

namespace HoneyRyderTask.UseCase.Services.Tasks.GetTask
{
    /// <summary>
    /// タスクを取得します。
    /// </summary>
    [UseCase]
    public class GetTaskUseCase
    {
        private readonly ITaskRepository taskRepository;

        /// <summary>
        /// タスクを取得します。
        /// </summary>
        /// <param name="taskRepository">タスクリポジトリ</param>
        public GetTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// 指定したタスクIDに該当するタスクを取得します。
        /// </summary>
        /// <param name="taskId">タスクID</param>
        /// <returns>
        /// 指定したタスクIDに該当するタスクが返されます。
        /// </returns>
        public TaskDto Execute(string taskId)
        {
            var targetId = TaskId.ValueOf(taskId);
            var task = this.taskRepository.Find(targetId);
            if (task == null) throw new DataNotFoundException(nameof(Task));
            return TaskDto.FromEntity(task);
        }
    }
}
