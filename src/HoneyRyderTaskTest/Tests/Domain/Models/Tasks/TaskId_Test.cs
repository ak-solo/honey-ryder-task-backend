using HoneyRyderTask.Domain.Exceptions;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskId - test
    /// </summary>
    public class TaskId_Test
    {
        [Fact(DisplayName = "[TaskId(value)] 指定した値でタスクIDを生成できる")]
        public void TaskId_Test1()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH53";

            // act
            var id = new TaskId(value);

            // assert
            Assert.Equal(value, id.Value);
        }

        [Fact(DisplayName = "[TaskId(value)] 指定した値がULID形式でない場合は例外を投げる")]
        public void TaskId_Test2()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH5";    // 25文字（ULIDは26文字）

            // act
            var action = () => new TaskId(value);

            // assert
            Assert.Throws<UlidFormatException>(action);
        }

        [Fact(DisplayName = "[NewId()] 新しいタスクID(ULID)を採番できる")]
        public void NewId_Test1()
        {
            // act
            var newId = TaskId.NewId();

            // assert
            Assert.True(ULID.IsULID(newId.Value));
        }
    }
}
