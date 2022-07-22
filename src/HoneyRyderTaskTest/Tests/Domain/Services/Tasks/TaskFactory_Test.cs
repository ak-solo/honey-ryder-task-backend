using System;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTask.Domain.Services.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Services.Tasks
{
    /// <summary>
    /// TaskFactory - test
    /// </summary>
    public class TaskFactory_Test
    {
        [Fact(DisplayName = "Create: 指定の内容でタスクを作成できる。")]
        public void Create_Test1()
        {
            // arrange
            var factory = new TaskFactory(dateTimeProvider: new DefaultDateTimeProvider());
            var param = new TaskCreateParam(
                Title: "タスクタイトル",
                Description: "タスク説明",
                DueDate: new DateTime(2022, 3, 31));

            // act
            var task = factory.Create(param);

            // assert
            Assert.Equal(param.Title, task.Title.Value);
            Assert.Equal(param.Description, task.Description.Value);
            Assert.Equal(param.DueDate, task.DueDate?.Value);
        }
    }
}
