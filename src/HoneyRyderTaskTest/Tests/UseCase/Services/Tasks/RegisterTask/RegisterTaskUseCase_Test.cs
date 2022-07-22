using System;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTask.Domain.Services.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks.RegisterTask;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.UseCase.Services.Tasks.RegisterTask
{
    /// <summary>
    /// RegisterTaskUseCase - test
    /// </summary>
    public class RegisterTaskUseCase_Test
    {
        [Fact(DisplayName = "Execute: 指定した内容でタスクを登録できる。")]
        public void Execute_Test1()
        {
            // arrange
            var factory = new TaskFactory(dateTimeProvider: new DefaultDateTimeProvider());
            Task registeredTask = default!;
            var mock = new Mock<ITaskRepository>();
            mock.Setup((x) => x.Add(It.IsAny<Task>()))
                .Callback<Task>(x => registeredTask = x);
            var repository = mock.Object;
            var useCase = new RegisterTaskUseCase(factory, repository);
            var command = new RegisterTaskCommand(
                Title: "タスクタイトル",
                Description: "タスク説明",
                DueDate: new DateTime(2022, 1, 1));

            // act
            useCase.Execute(command);

            // assert
            Assert.NotNull(registeredTask);
            Assert.Equal(command.Title, registeredTask.Title.Value);
            Assert.Equal(command.Description, registeredTask.Description.Value);
            Assert.Equal(command.DueDate, registeredTask.DueDate?.Value);
        }
    }
}
