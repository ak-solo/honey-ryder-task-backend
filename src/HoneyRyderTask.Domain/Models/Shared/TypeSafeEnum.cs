using System;
using System.Reflection;

namespace HoneyRyderTask.Domain.Models.Shared
{
    /// <summary>
    /// タイプセーフEnum
    /// </summary>
    public abstract record TypeSafeEnum<T>
        where T : TypeSafeEnum<T>
    {
        /// <summary>
        /// 指定の値でタイプセーフEnumを生成します。
        /// </summary>
        /// <param name="value">値</param>
        protected TypeSafeEnum(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タイプセーフEnumの値を返します。
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// 指定した値に該当するアイテムを取得します。
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>指定した値に該当するアイテムを返します。</returns>
        /// <exception cref="ArgumentException">指定した値に該当するアイテムが存在しない場合に例外が投げられます。</exception>
        public static T ValueOf(int value)
        {
            var item = GetItems().SingleOrDefault(t => t.Value == value);
            if (item == null) throw new KeyNotFoundException();
            return item;
        }

        /// <summary>
        /// 指定した値に該当するアイテムを取得します。
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>指定した値に該当するアイテムを返します。</returns>
        public static T? NullableValueOf(int? value)
        {
            if (value == null) return null;
            return ValueOf(value.GetValueOrDefault());
        }

        /// <summary>
        /// タイプセーフEnumのアイテムを取得します。
        /// </summary>
        /// <returns>
        /// タイプセーフEnumのアイテムを返します。
        /// </returns>
        public static IEnumerable<T> GetItems()
        {
            var fields = typeof(T).GetFields(
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.DeclaredOnly);
            return fields
                .Select(field => field.GetValue(null))
                .OfType<T>()
                .ToList();
        }
    }
}
