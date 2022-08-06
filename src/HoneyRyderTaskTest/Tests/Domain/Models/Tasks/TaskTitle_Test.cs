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
        [Fact(DisplayName = "ValueOf: 指定した値でタスクタイトルを生成できる。")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = "タスクタイトル";

            // act
            var title = TaskTitle.ValueOf(value);

            // assert
            Assert.Equal(value, title.Value);
        }

        [Fact(DisplayName = "ValueOf: 30文字以下であればタスクタイトルを生成できる。")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = new string('あ', 30); // 30文字

            // act
            var title = TaskTitle.ValueOf(value);

            // assert
            Assert.Equal(value, title.Value);
        }

        [Fact(DisplayName = "ValueOf: 30文字を超える場合は例外がスローされる。")]
        public void ValueOf_Test3()
        {
            // arrange
            var value = new string('あ', 31); // 31文字

            // act
            var act = () => TaskTitle.ValueOf(value);

            // assert
            Assert.Throws<MaxLengthException>(act);
        }

        [Fact(DisplayName = "Equals: 値ベースの等価比較ができる。")]
        public void Equals_Test1()
        {
            // arrange
            var value = "タスクタイトル";
            var title1 = TaskTitle.ValueOf(value);
            var title2 = TaskTitle.ValueOf(value);

            // act
            var actual = title1 == title2;

            // assert
            Assert.True(actual);
        }
    }
}
