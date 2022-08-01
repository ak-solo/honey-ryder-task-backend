using System.Transactions;
using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Tasks;
using Task = HoneyRyderTask.Domain.Models.Tasks.Task;
using TaskStatus = HoneyRyderTask.Domain.Models.Tasks.TaskStatus;

namespace HoneyRyderTask.UseCase.Services.Tasks.UpdateTaskStatus
{
    /// <summary>
    /// タスク状態更新ユースケース
    /// </summary>
    public class UpdateTaskStatusUseCase
    {
        private readonly ITaskRepository taskRepository;

        /// <summary>
        /// タスク状態更新ユースケースを作成します。
        /// </summary>
        /// <param name="taskRepository">タスクリポジトリ</param>
        public UpdateTaskStatusUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// タスク状態更新を実行します、
        /// </summary>
        /// <param name="command">タスク状態更新コマンド</param>
        public void Execute(UpdateTaskStatusCommand command)
        {
            using var scope = new TransactionScope();
            var task = this.taskRepository.Find(TaskId.ValueOf(command.Id));
            if (task == null) throw new DataNotFoundException(nameof(Task));
            task.ChangeStatus(TaskStatus.ValueOf(command.Status));
            this.taskRepository.Update(task);
            scope.Complete();
        }
    }
}
