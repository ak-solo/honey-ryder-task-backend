using System.Transactions;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.UseCase.Attributes;

namespace HoneyRyderTask.UseCase.Services.Tasks.RegisterTask
{
    /// <summary>
    /// タスク登録ユースケース
    /// </summary>
    [UseCase]
    public class RegisterTaskUseCase
    {
        private readonly ITaskFactory taskFactory;
        private readonly ITaskRepository taskRepository;

        /// <summary>
        /// タスクを登録します。
        /// </summary>
        /// <param name="taskFactory">タスクファクトリ</param>
        /// <param name="taskRepository">タスクリポジトリ</param>
        public RegisterTaskUseCase(
            ITaskFactory taskFactory,
            ITaskRepository taskRepository)
        {
            this.taskFactory = taskFactory;
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// タスクを登録します。
        /// </summary>
        /// <param name="command">タスク登録コマンド</param>
        public void Execute(RegisterTaskCommand command)
        {
            using var scope = new TransactionScope();
            var task = this.taskFactory.Create(command.ToTaskCreateParam());
            this.taskRepository.Add(task);
            scope.Complete();
        }
    }
}
