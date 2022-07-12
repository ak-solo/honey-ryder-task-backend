using System.Reflection;

namespace HoneyRyderTask.UseCase.Helpers
{
    public static class UseCaseHelper
    {
        /// <summary>
        /// ユースケース層のアセンブリを取得します。
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
