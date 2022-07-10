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
        [Fact(DisplayName = "[TaskCompletionDate(value)] 指定した値でタスク期限を生成できる")]
        public void TaskCompletionDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var completionDate = new TaskCompletionDate(value);

            // assert
            Assert.Equal(value, completionDate.Value);
        }

        [Fact(DisplayName = "[TaskCompletionDate(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void TaskCompletionDate_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var completionDate = new TaskCompletionDate(value);

            // assert
            Assert.NotEqual(value, completionDate.Value);   // 時間を含めると不一致
            Assert.Equal(value.Date, completionDate.Value); // 日付だけでみると一致
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var completionDate1 = new TaskCompletionDate(value);
            var completionDate2 = new TaskCompletionDate(value);

            // act
            var actual = completionDate1 == completionDate2;

            // assert
            Assert.True(actual);
        }
    }
}
