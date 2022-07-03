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
        [Fact(DisplayName = "[TaskDueDate(value)] 指定した値でタスク期限を生成できる")]
        public void TaskDueDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var dueDate = new TaskDueDate(value);

            // assert
            Assert.Equal(value, dueDate.Value);
        }

        [Fact(DisplayName = "[TaskDueDate(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void TaskDueDate_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var dueDate = new TaskDueDate(value);

            // assert
            Assert.NotEqual(value, dueDate.Value);      // 時間を含めると不一致
            Assert.Equal(value.Date, dueDate.Value);    // 日付だけでみると一致
        }
    }
}
