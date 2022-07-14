using System;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using Moq;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskCreationDate - test
    /// </summary>
    public class TaskCreationDate_Test
    {
        [Fact(DisplayName = "[Create(value)] 指定した値でタスク期限を生成できる")]
        public void Create_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);

            // act
            var creationDate = TaskCreationDate.Create(value);

            // assert
            Assert.Equal(value, creationDate.Value);
        }

        [Fact(DisplayName = "[Create(value)] 指定した値の時間部分は丸めて日付のみでタスク期限を生成する")]
        public void Create_Test2()
        {
            // arrange
            var value = new DateTime(2022, 1, 1, 12, 30, 45);

            // act
            var creationDate = TaskCreationDate.Create(value);

            // assert
            Assert.NotEqual(value, creationDate.Value);     // 時間を含めると不一致
            Assert.Equal(value.Date, creationDate.Value);   // 日付だけでみると一致
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var creationDate1 = TaskCreationDate.Create(value);
            var creationDate2 = TaskCreationDate.Create(value);

            // act
            var actual = creationDate1 == creationDate2;

            // assert
            Assert.True(actual);
        }

        [Fact(DisplayName = "[CreateWithCurrentDate()] 現在日付でタスク期限を生成できる")]
        public void CreateWithCurrentDate_Test1()
        {
            // arrange
            var value = new DateTime(2022, 1, 1);
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(x => x.GetCurrentDate()).Returns(() => value);
            var dateTimeProvider = mock.Object;

            // act
            var creationDate = TaskCreationDate.CreateWithCurrentDate(dateTimeProvider);

            // assert
            Assert.Equal(value, creationDate.Value);
        }
    }
}
