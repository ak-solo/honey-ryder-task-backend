using System;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskCompletionDate - test
    /// </summary>
    public class TaskCompletionDate_Test
    {
        [Fact(DisplayName = "ValueOf: 指定した値でタスク期限を生成できる。")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var completionDate = TaskCompletionDate.ValueOf(value);

            // assert
            Assert.Equal(value, completionDate.Value);
        }

        [Fact(DisplayName = "ValueOf: 指定した値の時間部分は丸めて日付のみでタスク期限を生成する。")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var completionDate = TaskCompletionDate.ValueOf(value);

            // assert
            Assert.NotEqual(value, completionDate.Value);   // 時間を含めると不一致
            Assert.Equal(value.Date, completionDate.Value); // 日付だけでみると一致
        }

        [Fact(DisplayName = "NullableValueOf: タスク完了日をNULL許容型で生成できる。")]
        public void NullableValueOf_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var dueDate = TaskCompletionDate.NullableValueOf(value);

            // assert
            Assert.IsType<TaskCompletionDate?>(dueDate);
            Assert.Equal(value, dueDate?.Value);
        }

        [Fact(DisplayName = "NullableValueOf: NULLを指定した場合はNULLを返す。")]
        public void NullableValueOf_Test2()
        {
            // arrange
            DateTime? value = null;

            // act
            var dueDate = TaskCompletionDate.NullableValueOf(value);

            // assert
            Assert.Null(dueDate);
        }

        [Fact(DisplayName = "Equals: 値ベースの等価比較ができる。")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var completionDate1 = TaskCompletionDate.ValueOf(value);
            var completionDate2 = TaskCompletionDate.ValueOf(value);

            // act
            var actual = completionDate1 == completionDate2;

            // assert
            Assert.True(actual);
        }

        [Fact(DisplayName = "CreateWithCurrentDate: 現在日付でタスク期限を生成できる。")]
        public void CreateWithCurrentDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(x => x.GetCurrentDate()).Returns(() => value);
            var dateTimeProvider = mock.Object;

            // act
            var creationDate = TaskCompletionDate.CreateWithCurrentDate(dateTimeProvider);

            // assert
            Assert.Equal(value, creationDate.Value);
        }
    }
}
