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
        [Fact(DisplayName = "ValueOf: 指定した値でタスクIDを生成できる。")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH53";

            // act
            var id = TaskId.ValueOf(value);

            // assert
            Assert.Equal(value, id.Value);
        }

        [Fact(DisplayName = "ValueOf: 指定した値がULID形式でない場合は例外を投げる")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH5";    // 25文字（ULIDは26文字）

            // act
            var action = () => TaskId.ValueOf(value);

            // assert
            Assert.Throws<UlidFormatException>(action);
        }

        [Fact(DisplayName = "NewId: 新しいタスクID(ULID)を採番できる")]
        public void NewId_Test1()
        {
            // act
            var newId = TaskId.NewId();

            // assert
            Assert.True(ULID.IsULID(newId.Value));
        }

        [Fact(DisplayName = "Equals: 値ベースの等価比較ができる")]
        public void Equals_Test1()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH53";
            var id1 = TaskId.ValueOf(value);
            var id2 = TaskId.ValueOf(value);

            // act
            var actual = id1 == id2;

            // assert
            Assert.True(actual);
        }
    }
}
