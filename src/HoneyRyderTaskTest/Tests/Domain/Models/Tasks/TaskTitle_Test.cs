using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskTitle - test
    /// </summary>
    public class TaskTitle_Test
    {
        [Fact(DisplayName = "[TaskTitle(vlaue)] 指定した値でタスクタイトルを生成できる")]
        public void TaskTitle_Test1()
        {
            // arrange
            var value = "タスクタイトル";

            // act
            var title = new TaskTitle(value);

            // assert
            Assert.Equal(value, title.Value);
        }

        [Fact(DisplayName = "[TaskTitle(value)] 30文字以下であればタスクタイトルを生成できる")]
        public void TaskTitle_Test2()
        {
            // arrange
            var value = new string('あ', 30); // 30文字

            // act
            var title = new TaskTitle(value);

            // assert
            Assert.Equal(value, title.Value);
        }

        [Fact(DisplayName = "[TaskTitle(value)] 30文字を超える場合は例外がスローされる")]
        public void TaskTitle_Test3()
        {
            // arrange
            var value = new string('あ', 31); // 31文字

            // act
            var act = () => new TaskTitle(value);

            // assert
            Assert.Throws<MaxLengthException>(act);
        }

        [Fact(DisplayName = "[Equals] 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = "タスクタイトル";
            var title1 = new TaskTitle(value);
            var title2 = new TaskTitle(value);

            // act
            var actual = title1 == title2;

            // assert
            Assert.True(actual);
        }
    }
}
