using System.Transactions;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTask.Infrastructure.PostgreSQL;
using HoneyRyderTask.Infrastructure.PostgreSQL.Repositories.Tasks;
using HoneyRyderTaskTest.Builders.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Infrastructure.PostgreSQL.Repositories.Tasks
{
    /// <summary>
    /// TaskRepository - test
    /// </summary>
    public class TaskRepsitory_Test
    {
        [Fact(DisplayName = "Find: 指定したタスクIDに該当するタスクを取得できる。")]
        public void Find_Test1()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var repository = this.CreateTaskRepository();
            var task = new TaskBuilder().Build();
            repository.Add(task);

            // act
            var data = repository.Find(task.Id);

            // assert
            Assert.Equal(task.Id, data?.Id);
            Assert.Equal(task.Title, data?.Title);
            Assert.Equal(task.Description, data?.Description);
            Assert.Equal(task.Status, data?.Status);
            Assert.Equal(task.DueDate, data?.DueDate);
            Assert.Equal(task.CreationDate, data?.CreationDate);
            Assert.Equal(task.CompletionDate, data?.CompletionDate);
        }

        [Fact(DisplayName = "Find: 指定したタスクIDに該当するタスクが存在しない場合はnullを返す。")]
        public void Find_Test2()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var repository = this.CreateTaskRepository();
            var task = new TaskBuilder().Build();
            repository.Add(task);

            var targetId = TaskId.ValueOf("01G85WHT1VCHA4ATBSH6NPS19M");
            Assert.NotEqual(task.Id, targetId);             // 前提条件：検索するタスクIDが、登録済のタスクのIDと異なる。

            // act
            var data = repository.Find(targetId);

            // assert
            Assert.Null(data);
        }

        [Fact(DisplayName = "Add: 引数で渡したタスクがリポジトリに登録される。")]
        public void Add_Test1()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var repository = this.CreateTaskRepository();
            var task = new TaskBuilder().Build();

            var before = repository.Find(task.Id);
            Assert.Null(before);                            // 前提条件：追加前にはデータが存在しないことを確認する。

            // act
            repository.Add(task);

            // assert
            var addedTask = repository.Find(task.Id);
            Assert.NotNull(addedTask);
            Assert.Equal(task.Id, addedTask?.Id);
            Assert.Equal(task.Title, addedTask?.Title);
            Assert.Equal(task.Description, addedTask?.Description);
            Assert.Equal(task.Status, addedTask?.Status);
            Assert.Equal(task.DueDate, addedTask?.DueDate);
            Assert.Equal(task.CreationDate, addedTask?.CreationDate);
            Assert.Equal(task.CompletionDate, addedTask?.CompletionDate);
        }

        [Fact(DisplayName = "Add: 引数で渡したタスクでリポジトリを更新できる。")]
        public void Update_Test1()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var repository = this.CreateTaskRepository();
            var task = new TaskBuilder()
                .WithStatus(TaskStatus.NotStarted.Value)
                .Build();
            repository.Add(task);
            task.ChangeStatus(TaskStatus.Started);          // タスク状態を NotStarted -> Started に変更

            // act
            repository.Update(task);

            // assert
            var updatedTask = repository.Find(task.Id);
            Assert.Equal(task.Status.Value, updatedTask?.Status.Value);
        }

        private TaskRepository CreateTaskRepository()
        {
            return new TaskRepository(
                new HoneyRyderTaskDbContext(),
                new DefaultDateTimeProvider());
        }
    }
}
