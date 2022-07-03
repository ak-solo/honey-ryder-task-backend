using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskCreatedDate - test
    /// </summary>
    public class TaskCreatedDate_Test
    {
        [Fact(DisplayName = "[TaskCreatedDate(value)] 指定した値でタスク期限を生成できる")]
        public void TaskCreatedDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var createdDate = new TaskCreatedDate(value);

            // assert
            Assert.Equal(value, createdDate.Value);
        }

        [Fact(DisplayName = "[TaskCreatedDate(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void TaskCreatedDate_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var createdDate = new TaskCreatedDate(value);

            // assert
            Assert.NotEqual(value, createdDate.Value);      // 時間を含めると不一致
            Assert.Equal(value.Date, createdDate.Value);    // 日付だけでみると一致
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var createDate1 = new TaskCreatedDate(value);
            var createDate2 = new TaskCreatedDate(value);

            // act
            var actual = createDate1 == createDate2;

            // assert
            Assert.True(actual);
        }
    }
}
