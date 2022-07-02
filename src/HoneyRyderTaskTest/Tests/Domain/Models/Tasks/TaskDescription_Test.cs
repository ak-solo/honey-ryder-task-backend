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
        [Fact(DisplayName = "[TaskDescription(value)] 指定した値でタスク説明を生成できる")]
        public void TaskDescription_Test1()
        {
            // arrange
            var value = new string("タスク説明");

            // act
            var description = new TaskDescription(value);

            // assert
            Assert.Equal(value, description.Value);
        }

        [Fact(DisplayName = "[TaskDescription(value)] 1,000文字以下であればタスク説明を生成できる")]
        public void TaskDescription_Test2()
        {
            // arrange
            var value = new string('あ', 1000); // 1,000文字

            // act
            var description = new TaskDescription(value);

            // assert
            Assert.Equal(value, description.Value);
        }

        [Fact(DisplayName = "[TaskDescription(value)] 1,000文字を超える場合は例外がスローされる")]
        public void TaskDescription_Test3()
        {
            // arrange
            var value = new string('あ', 1001); // 1,001文字

            // act
            var act = () => new TaskDescription(value);

            // assert
            Assert.Throws<MaxLengthException>(act);
        }
    }
}
