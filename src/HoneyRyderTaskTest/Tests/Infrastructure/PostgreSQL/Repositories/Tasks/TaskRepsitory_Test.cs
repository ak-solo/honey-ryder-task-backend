using System.Linq;
using System.Transactions;
using HoneyRyderTask.Domain.Models.Tasks;
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
        [Fact(DisplayName = "[Add(task)] 指定したタスクIDに該当するタスクを取得できる")]
        public void Find_Test1()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var context = new HoneyRyderTaskDbContext();
            var repository = new TaskRepository(context);
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

        [Fact(DisplayName = "[Add(task)] 指定したタスクIDに該当するタスクが存在しない場合はnullを返す。")]
        public void Find_Test2()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var context = new HoneyRyderTaskDbContext();
            var repository = new TaskRepository(context);
            var targetId = TaskId.Create("01G85WHT1VCHA4ATBSH6NPS19M");
            var task = new TaskBuilder().Build();
            repository.Add(task);
            Assert.NotEqual(task.Id, targetId);             // 前提条件：検索するタスクIDが、登録済のタスクのIDと異なる。

            // act
            var data = repository.Find(targetId);

            // assert
            Assert.Null(data);
        }

        [Fact(DisplayName = "[Add(task)] 引数で渡したタスクがリポジトリに登録される")]
        public void Add_Test1()
        {
            // arrange
            using var scope = new TransactionScope();       // テスト終了後にロールバックされるようにトランザクションを開始しておく。
            var context = new HoneyRyderTaskDbContext();
            var repository = new TaskRepository(context);
            var task = new TaskBuilder().Build();

            // act
            repository.Add(task);

            // assert
            var addedData = context.Tasks.Single(t => t.TaskId == task.Id.Value);
            Assert.Equal(task.Id.Value, addedData.TaskId);
            Assert.Equal(task.Title.Value, addedData.Title);
            Assert.Equal(task.Description.Value, addedData.Description);
            Assert.Equal(task.Status.Value, addedData.Status);
            Assert.Equal(task.DueDate?.Value, addedData.DueDate);
            Assert.Equal(task.CreationDate.Value, addedData.CreationDate);
            Assert.Equal(task.CompletionDate?.Value, addedData.CompletionDate);
        }
    }
}
