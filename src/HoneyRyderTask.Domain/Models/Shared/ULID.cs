using System;
using NUlid;

namespace HoneyRyderTask.Domain.Models.Shared
{
    /// <summary>
    /// ULID（Universally Unique Lexicographically Sortable Identifier）
    /// 重複しない一意なIDを生成し、かつミリ秒単位で時系列ソートができる値
    /// </summary>
    public record ULID
    {
        private ULID(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// ULID
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 新しいULIDを採番します。
        /// </summary>
        /// <returns>新しいULID</returns>
        public static ULID NewULID()
        {
            return new ULID(Ulid.NewUlid().ToString());
        }

        /// <summary>
        /// 指定した値がULIDであるかどうかを返します。
        /// ULIDであればtrue。それ以外はfalseを返します。
        /// </summary>
        /// <param name="value">ULIDであるかを確認する対象の値を指定します。</param>
        /// <returns>
        /// 指定した値がULIDであればtrue。それ以外はfalseを返します。
        /// </returns>
        public static bool IsULID(string value)
        {
            return Ulid.TryParse(value, out _);
        }
    }
}
