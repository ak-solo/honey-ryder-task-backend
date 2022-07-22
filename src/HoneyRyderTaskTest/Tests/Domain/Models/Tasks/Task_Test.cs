using System;
using System.Collections.Generic;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTaskTest.Builders.Domain.Models.Tasks;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// Task -test
    /// </summary>
    public class Task_Test
    {
        public static IEnumerable<object[]> TestData_ChangeStatus_Test2()
        {
            yield return new object[] { TaskStatus.NotStarted };
            yield return new object[] { TaskStatus.Started };
        }

        [Fact(DisplayName = "Create: 指定した値でタスクを生成できる。")]
        public void Create_Test1()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));

            // act
            var task = Task.Create(title, description, dueDate, new DefaultDateTimeProvider());

            // assert
            Assert.Equal(title, task.Title);
            Assert.Equal(description, task.Description);
            Assert.Equal(dueDate, task.DueDate);
        }

        [Fact(DisplayName = "Create: タスク作成時、タスク期限は任意項目。nullを設定可能。")]
        public void Create_Test2()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            TaskDueDate? dueDate = null;

            // act
            var task = Task.Create(title, description, dueDate, new DefaultDateTimeProvider());

            // assert
            Assert.Null(task.DueDate);
        }

        [Fact(DisplayName = "Create: タスク作成時、タスクIDには自動採番されたULIDが設定される。")]
        public void Create_Test3()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));

            // act
            var task = Task.Create(title, description, dueDate, new DefaultDateTimeProvider());

            // assert
            Assert.True(ULID.IsULID(task.Id.Value));
        }

        [Fact(DisplayName = "Create: タスク作成時、タスク状態には「未着手」が設定される。")]
        public void Create_Test4()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));

            // act
            var task = Task.Create(title, description, dueDate, new DefaultDateTimeProvider());

            // assert
            Assert.Equal(TaskStatus.NotStarted, task.Status);
        }

        [Fact(DisplayName = "Create: タスク作成時、タスク作成日には現在日付が設定される。")]
        public void Create_Test5()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(x => x.GetCurrentDate()).Returns(() => new DateTime(2022, 1, 1));
            var dateTimeProvider = mock.Object;

            // act
            var task = Task.Create(title, description, dueDate, dateTimeProvider);

            // assert
            Assert.Equal(dateTimeProvider.GetCurrentDate(), task.CreationDate.Value);
        }

        [Fact(DisplayName = "Create: タスク作成時、タスク完了日にはnullが設定される。")]
        public void Create_Test6()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));

            // act
            var task = Task.Create(title, description, dueDate, new DefaultDateTimeProvider());

            // assert
            Assert.Null(task.CompletionDate);
        }

        [Fact(DisplayName = "Reconstruct: 指定した値でタスクを再構築できる。")]
        public void Reconstruct_Test1()
        {
            // arrange
            var id = TaskId.NewId();
            var title = TaskTitle.ValueOf("タスクタイトル");
            var description = TaskDescription.ValueOf("タスク説明");
            var status = TaskStatus.NotStarted;
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 3, 31));
            var createdDate = TaskCreationDate.ValueOf(new DateTime(2022, 1, 1));
            var completedDate = TaskCompletionDate.ValueOf(new DateTime(2022, 2, 1));
            var dateTimeProvider = new DefaultDateTimeProvider();

            // act
            var task = Task.Reconstruct(
                id,
                title,
                description,
                status,
                dueDate,
                createdDate,
                completedDate,
                dateTimeProvider);

            // assert
            Assert.Equal(id, task.Id);
            Assert.Equal(title, task.Title);
            Assert.Equal(description, task.Description);
            Assert.Equal(status, task.Status);
            Assert.Equal(dueDate, task.DueDate);
            Assert.Equal(createdDate, task.CreationDate);
            Assert.Equal(completedDate, task.CompletionDate);
        }

        [Fact(DisplayName = "ChangeStatus: タスク状態：完了に変更した場合、タスク完了日には現在日付が設定される。")]
        public void ChangeStatus_Test1()
        {
            // arrange
            var currentDate = new DateTime(2022, 1, 1);
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(x => x.GetCurrentDate()).Returns(() => currentDate);
            var dateTimeProvider = mock.Object;
            var task = new TaskBuilder()
                .WithStatus(TaskStatus.NotStarted.Value)
                .WithCompletionDate(null)
                .WithDateTimeProvider(dateTimeProvider)
                .Build();

            // act
            task.ChangeStatus(TaskStatus.Completed);

            // assert
            Assert.Equal(TaskStatus.Completed, task.Status);
            Assert.NotNull(task.CompletionDate);
            Assert.Equal(currentDate, task.CompletionDate?.Value);
        }

        [Theory(DisplayName = "ChangeStatus: タスク状態：完了以外に変更した場合、タスク完了日がクリアされる。")]
        [MemberData(nameof(TestData_ChangeStatus_Test2))]
        public void ChangeStatus_Test2(TaskStatus status)
        {
            // arrange
            var task = new TaskBuilder()
                .WithStatus(TaskStatus.Completed.Value)
                .WithCompletionDate(new DateTime(2022, 4, 1))
                .Build();

            // act
            task.ChangeStatus(status);

            // assert
            Assert.Equal(status, task.Status);
            Assert.Null(task.CompletionDate);
        }
    }
}
