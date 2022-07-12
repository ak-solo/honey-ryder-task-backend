using System;

namespace System
{
    /// <summary>
    /// Type（拡張メソッド）
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// 指定の属性を持っているかどうかを返します。
        /// 持っている場合はtrue。それ以外はfalseを返します。
        /// </summary>
        /// <typeparam name="TAttributeType">属性タイプ</typeparam>
        /// <param name="type">タイプ</param>
        /// <returns></returns>
        public static bool HasAttribute<TAttributeType>(this Type type)
        {
            var attr = type.GetCustomAttributes(typeof(TAttributeType), inherit: false);
            return attr.Count() > 0;
        }
    }
}
