using System.Collections.Generic;
using System.Linq;
using HoneyRyderTask.Domain.Models.Shared;
using Xunit;

#pragma warning disable SA1401

namespace HoneyRyderTaskTest.Tests.Domain.Models.Shared
{
    /// <summary>
    /// TypeSafeEnum - test
    /// </summary>
    public class TypeSafeEnum_Test
    {
        /// <summary>
        /// TypeSafeEnum（抽象クラス）のテストである為、テスト用に作成した実装クラスを使用する。
        /// </summary>
        private record TestTypeSafeEnum : TypeSafeEnum<TestTypeSafeEnum>
        {
            public static TestTypeSafeEnum Item1 = new TestTypeSafeEnum(value: 1);
            public static TestTypeSafeEnum Item2 = new TestTypeSafeEnum(value: 2);
            public static TestTypeSafeEnum Item3 = new TestTypeSafeEnum(value: 3);

            private TestTypeSafeEnum(int value)
                : base(value)
            {
            }
        }

        [Fact(DisplayName = "[GetItem(value)] 指定した値に該当するアイテムが取得できる。")]
        public void GetItem_Test1()
        {
            // arrange
            var value = 1;

            // act
            var actual = TestTypeSafeEnum.GetItem(value);     // 抽象クラスのテストである為、テスト用に作成した実装クラスを使用する。

            // assert
            Assert.Equal(actual, TestTypeSafeEnum.Item1);
        }

        [Fact(DisplayName = "[GetItem(value)] 指定した値に該当するアイテムが存在しない場合は例外が投げられる。")]
        public void GetItem_Test2()
        {
            // arrange
            var value = 4;

            // act
            var act = () => TestTypeSafeEnum.GetItem(value);  // 抽象クラスのテストである為、テスト用に作成した実装クラスを使用する。

            // assert
            Assert.Throws<KeyNotFoundException>(act);
        }

        [Fact(DisplayName = "[GetItems()] 定義してあるアイテムを全て取得できる。")]
        public void GetItems_Test1()
        {
            // act
            var items = TestTypeSafeEnum.GetItems();          // 抽象クラスのテストである為、テスト用に作成した実装クラスを使用する。

            // assert
            Assert.Equal(3, items.Count());
            Assert.Equal(TestTypeSafeEnum.Item1, items.ElementAt(0));
            Assert.Equal(TestTypeSafeEnum.Item2, items.ElementAt(1));
            Assert.Equal(TestTypeSafeEnum.Item3, items.ElementAt(2));
        }
    }
}
