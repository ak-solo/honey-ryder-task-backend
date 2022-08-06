using System.Linq;
using HoneyRyderTask.Domain.Models.Shared;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Models.Shared
{
    /// <summary>
    /// ULID - test
    /// </summary>
    public class ULID_Test
    {
        [Fact(DisplayName = "NewULID: 新しいULIDを採番できる。")]
        public void NewULID_Test1()
        {
            // act
            var id = ULID.NewULID();

            // assert
            Assert.Equal(26, id.Value.Length);
        }

        [Fact(DisplayName = "NewULID: 毎回異なるIDが採番される（100回実行して確認）。")]
        public void NewULID_Test2()
        {
            // act
            var ids = Enumerable.Range(1, 100).Select((i) => ULID.NewULID());

            // assert
            var isDuplicated = ids.IsDuplicated(id => id.Value);
            Assert.False(isDuplicated);
        }

        [Fact(DisplayName = "IsULID: 指定した値がULIDであれば true を返す。")]
        public void IsULID_Test1()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH53";   // 26文字

            // act
            var isULID = ULID.IsULID(value);

            // assert
            Assert.True(isULID);
        }

        [Fact(DisplayName = "IsULID: 26文字未満の場合は false を返す。")]
        public void IsULID_Test2()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH5";    // 25文字

            // act
            var isULID = ULID.IsULID(value);

            // assert
            Assert.False(isULID);
        }
    }
}
