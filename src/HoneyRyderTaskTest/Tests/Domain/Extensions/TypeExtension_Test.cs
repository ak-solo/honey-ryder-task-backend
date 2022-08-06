using System;
using HoneyRyderTask.UseCase.Attributes;
using Xunit;

namespace HoneyRyderTaskTest.Tests.Domain.Extensions
{
    /// <summary>
    /// TypeExtension -test
    /// </summary>
    public class TypeExtension_Test
    {
        [Fact(DisplayName = "HasAttribute: 指定した属性を持ったクラスであれば true を返す。")]
        public void HasAttribute_Test1()
        {
            // act
            var actual = typeof(Class1).HasAttribute<UseCaseAttribute>();

            // assert
            Assert.True(actual);
        }

        [Fact(DisplayName = "HasAttribute: 指定した属性を持っていないクラスであれば false を返す。")]
        public void HasAttribute_Test2()
        {
            // act
            var actual = typeof(Class2).HasAttribute<UseCaseAttribute>();

            // assert
            Assert.False(actual);
        }

        [UseCase]
        private class Class1
        {
        }

        private class Class2
        {
        }
    }
}
