using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskCompletionDate - test
    /// </summary>
    public class TaskCompletionDate_Test
    {
        [Fact(DisplayName = "[Create(value)] 指定した値でタスク期限を生成できる")]
        public void Create_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var completionDate = TaskCompletionDate.Create(value);

            // assert
            Assert.Equal(value, completionDate.Value);
        }

        [Fact(DisplayName = "[Create(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void Create_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var completionDate = TaskCompletionDate.Create(value);

            // assert
            Assert.NotEqual(value, completionDate.Value);   // 時間を含めると不一致
            Assert.Equal(value.Date, completionDate.Value); // 日付だけでみると一致
        }

        [Fact(DisplayName = "[CreateNullable(value)] タスク完了日をNULL許容型で生成できる")]
        public void CreateNullable_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var dueDate = TaskCompletionDate.CreateNullable(value);

            // assert
            Assert.IsType<TaskCompletionDate?>(dueDate);
            Assert.Equal(value, dueDate?.Value);
        }

        [Fact(DisplayName = "[CreateNullable(value)] NULLを指定した場合はNULLを返す")]
        public void CreateNullable_Test2()
        {
            // arrange
            DateTime? value = null;

            // act
            var dueDate = TaskCompletionDate.CreateNullable(value);

            // assert
            Assert.Null(dueDate);
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var completionDate1 = TaskCompletionDate.Create(value);
            var completionDate2 = TaskCompletionDate.Create(value);

            // act
            var actual = completionDate1 == completionDate2;

            // assert
            Assert.True(actual);
        }
    }
}
