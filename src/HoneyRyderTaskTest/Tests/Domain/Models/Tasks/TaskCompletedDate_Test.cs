using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskCompletedDate - test
    /// </summary>
    public class TaskCompletedDate_Test
    {
        [Fact(DisplayName = "[TaskCompletedDate(value)] 指定した値でタスク期限を生成できる")]
        public void TaskCompletedDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var completedDate = new TaskCompletedDate(value);

            // assert
            Assert.Equal(value, completedDate.Value);
        }

        [Fact(DisplayName = "[TaskCompletedDate(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void TaskCompletedDate_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var completedDate = new TaskCompletedDate(value);

            // assert
            Assert.NotEqual(value, completedDate.Value);    // 時間を含めると不一致
            Assert.Equal(value.Date, completedDate.Value);  // 日付だけでみると一致
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var completedDate1 = new TaskCompletedDate(value);
            var completedDate2 = new TaskCompletedDate(value);

            // act
            var actual = completedDate1 == completedDate2;

            // assert
            Assert.True(actual);
        }
    }
}
