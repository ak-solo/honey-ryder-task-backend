using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskDueDate - test
    /// </summary>
    public class TaskDueDate_Test
    {
        [Fact(DisplayName = "[Create(value)] 指定した値でタスク期限を生成できる")]
        public void Create_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var dueDate = TaskDueDate.Create(value);

            // assert
            Assert.Equal(value, dueDate.Value);
        }

        [Fact(DisplayName = "[Create(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void Create_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var dueDate = TaskDueDate.Create(value);

            // assert
            Assert.NotEqual(value, dueDate.Value);      // 時間を含めると不一致
            Assert.Equal(value.Date, dueDate.Value);    // 日付だけでみると一致
        }

        [Fact(DisplayName = "[CreateNullable(value)] タスク期限をNULL許容型で生成できる")]
        public void CreateNullable_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var dueDate = TaskDueDate.CreateNullable(value);

            // assert
            Assert.IsType<TaskDueDate?>(dueDate);
            Assert.Equal(value, dueDate?.Value);
        }

        [Fact(DisplayName = "[CreateNullable(value)] NULLを指定した場合はNULLを返す")]
        public void CreateNullable_Test2()
        {
            // arrange
            DateTime? value = null;

            // act
            var dueDate = TaskDueDate.CreateNullable(value);

            // assert
            Assert.Null(dueDate);
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var dueDate1 = TaskDueDate.Create(value);
            var dueDate2 = TaskDueDate.Create(value);

            // act
            var actual = dueDate1 == dueDate2;

            // assert
            Assert.True(actual);
        }
    }
}
