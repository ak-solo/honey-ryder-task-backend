using System.Linq;
using Xunit;

namespace Domain.Extensions
{
    /// <summary>
    /// IEnumerable（拡張メソッド）- test
    /// </summary>
    public class IEnumerableExtension_Test
    {
        [Fact(DisplayName = "IsDuplicated: リスト内の要素に重複があれば true を返す。")]
        public void IsDuplicated_Test1()
        {
            // arrange
            var values = new int[] { 1, 2, 3, 4, 5, 6, 3 }; // 3が重複している

            // act
            var isDuplicated = values.IsDuplicated();

            // assert
            Assert.True(isDuplicated);
        }

        [Fact(DisplayName = "IsDuplicated: リスト内の要素に重複がなければ false を返す。")]
        public void IsDuplicated_Test2()
        {
            // arrange
            var values = new int[] { 1, 2, 3, 4, 5, 6, 7 }; // 重複なし

            // act
            var isDuplicated = values.IsDuplicated();

            // assert
            Assert.False(isDuplicated);
        }

        [Fact(DisplayName = "IsDuplicated: リスト内の指定要素に重複がなければ false を返す。")]
        public void IsDuplicated_Test3()
        {
            // arrange
            var values = new[]
            {
                new { id = 1, name = "abc", age = 20 },
                new { id = 2, name = "def", age = 30 },
                new { id = 3, name = "abc", age = 40 },
            };

            // act
            var isDuplicated = values.IsDuplicated((value) => value.name);  // nameには重複がある。

            // assert
            Assert.True(isDuplicated);
        }

        [Fact(DisplayName = "IsDuplicated: リスト内の指定要素に重複がなければ false を返す。")]
        public void IsDuplicated_Test4()
        {
            // arrange
            var values = new[]
            {
                new { id = 1, name = "abc", age = 20 },
                new { id = 2, name = "def", age = 30 },
                new { id = 3, name = "abc", age = 40 },
            };

            // act
            var isDuplicated = values.IsDuplicated((value) => value.id);    // idには重複がない。

            // assert
            Assert.False(isDuplicated);
        }
    }
}
