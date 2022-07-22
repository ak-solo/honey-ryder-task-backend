using System;
using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskDescription - test
    /// </summary>
    public class TaskDescription_Test
    {
        [Fact(DisplayName = "ValueOf: 指定した値でタスク説明を生成できる。")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = new string("タスク説明");

            // act
            var description = TaskDescription.ValueOf(value);

            // assert
            Assert.Equal(value, description.Value);
        }

        [Fact(DisplayName = "ValueOf: 1,000文字以下であればタスク説明を生成できる。")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = new string('あ', 1000); // 1,000文字

            // act
            var description = TaskDescription.ValueOf(value);

            // assert
            Assert.Equal(value, description.Value);
        }

        [Fact(DisplayName = "ValueOf: 1,000文字を超える場合は例外がスローされる。")]
        public void ValueOf_Test3()
        {
            // arrange
            var value = new string('あ', 1001); // 1,001文字

            // act
            var act = () => TaskDescription.ValueOf(value);

            // assert
            Assert.Throws<MaxLengthException>(act);
        }

        [Fact(DisplayName = "Equals: 値ベースの等価比較ができる。")]
        public void Equals_Test1()
        {
            // arrange
            var value = "タスク説明";
            var description1 = TaskDescription.ValueOf(value);
            var description2 = TaskDescription.ValueOf(value);

            // act
            var actual = description1 == description2;

            // assert
            Assert.True(actual);
        }
    }
}
