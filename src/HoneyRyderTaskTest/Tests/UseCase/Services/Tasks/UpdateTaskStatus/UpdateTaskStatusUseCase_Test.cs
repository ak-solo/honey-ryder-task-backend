using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks.UpdateTaskStatus;
using HoneyRyderTaskTest.Builders.Domain.Models.Tasks;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.UseCase.Services.Tasks.UpdateTaskStatus
{
    public class UpdateTaskStatusUseCase_Test
    {
        [Fact(DisplayName = "Execute: 指定した内容でタスク状態を更新できる。")]
        public void Execute_Test1()
        {
            // arrange
            Task task = new TaskBuilder()
                .WithStatus(TaskStatus.NotStarted.Value)
                .Build();
            Task updatedTask = default!;

            var mock = new Mock<ITaskRepository>();
            mock.Setup(x => x.Find(task.Id))
                .Returns<TaskId>(_ => task);
            mock.Setup(x => x.Update(It.IsAny<Task>()))
                .Callback<Task>(x => updatedTask = x);
            var repository = mock.Object;

            var useCase = new UpdateTaskStatusUseCase(repository);
            var command = new UpdateTaskStatusCommand(
                Id: task.Id.Value,
                Status: TaskStatus.Started.Value);

            // act
            useCase.Execute(command);

            // assert
            Assert.NotNull(updatedTask);
            Assert.Equal(command.Status, updatedTask.Status.Value);
        }
    }
}
