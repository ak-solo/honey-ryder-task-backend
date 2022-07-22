using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks.GetTask;
using HoneyRyderTaskTest.Builders.Domain.Models.Tasks;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.UseCase.Services.Tasks.GetTask
{
    /// <summary>
    /// GetTaskUseCase - test
    /// </summary>
    public class GetTaskUseCase_Test
    {
        [Fact(DisplayName = "Execute: リポジトリから取得したタスクをDTOに詰め替えて返す。")]
        public void Execute_Test1()
        {
            // arrange
            var task = new TaskBuilder().Build();
            var mock = new Mock<ITaskRepository>();
            mock.Setup(r => r.Find(It.IsAny<TaskId>())).Returns(() => task);
            var taskRepository = mock.Object;
            var usecase = new GetTaskUseCase(taskRepository);

            // act
            var actualDto = usecase.Execute(task.Id.Value);

            // assert
            var expectedDto = new TaskDto(
                TaskId: task.Id.Value,
                Title: task.Title.Value,
                Description: task.Description.Value,
                Status: task.Status.Value,
                DueDate: task.DueDate?.Value,
                CreationDate: task.CreationDate.Value,
                CompletionDate: task.CompletionDate?.Value);
            Assert.Equal(expectedDto, actualDto);
        }

        [Fact(DisplayName = "Execute: リポジトリから取得したタスクがnullの場合は例外を投げる。")]
        public void Execute_Test2()
        {
            // arrange
            var task = new TaskBuilder().Build();
            var mock = new Mock<ITaskRepository>();
            mock.Setup(r => r.Find(It.IsAny<TaskId>())).Returns(() => null);    // リポジトリからnullが返却された場合
            var taskRepository = mock.Object;
            var usecase = new GetTaskUseCase(taskRepository);

            // act
            var act = () => usecase.Execute(task.Id.Value);

            // assert
            var ex = Assert.Throws<DataNotFoundException>(act);
            Assert.Equal(nameof(Task), ex.DataName);
        }
    }
}
