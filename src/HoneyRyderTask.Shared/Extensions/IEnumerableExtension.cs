namespace HoneyRyderTask.Shared.Extensions
{
    /// <summary>
    /// IEnumerable（拡張メソッド）
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// リスト内に重複する要素があるかどうかを返します。
        /// 重複する要素があれば true。なければ false を返します。
        /// </summary>
        /// <typeparam name="T">リスト要素の型</typeparam>
        /// <param name="list">リスト</param>
        /// <returns>リスト内に重複する要素があれば true。なければ falseを返します。</returns>
        public static bool IsDuplicated<T>(this IEnumerable<T> list)
        {
            return list.GroupBy((item) => item).Any(g => g.Count() > 1);
        }

        /// <summary>
        /// リスト内の指定の要素に重複があるかどうかを返します。
        /// 重複する要素があれば true。なければ false を返します。
        /// </summary>
        /// <typeparam name="T1">リスト要素の型</typeparam>
        /// <typeparam name="T2">キー項目の型</typeparam>
        /// <param name="list">リスト</param>
        /// <param name="keySelector">キー項目</param>
        /// <returns>リスト内の指定の要素に重複があれば true。なければ falseを返します。</returns>
        public static bool IsDuplicated<T1, T2>(this IEnumerable<T1> list, Func<T1, T2> keySelector)
        {
            return list.GroupBy(keySelector).Any(g => g.Count() > 1);
        }
    }
}
