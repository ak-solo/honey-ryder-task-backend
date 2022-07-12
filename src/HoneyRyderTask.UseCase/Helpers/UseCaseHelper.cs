using System.Reflection;

namespace HoneyRyderTask.UseCase.Helpers
{
    /// <summary>
    /// ユースケース - helper
    /// </summary>
    public static class UseCaseHelper
    {
        /// <summary>
        /// ユースケース層のアセンブリを取得します。
        /// </summary>
        /// <returns>
        /// ユースケース層のアセンブリを返します。
        /// </returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
