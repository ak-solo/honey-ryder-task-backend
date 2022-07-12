using HoneyRyderTask.UseCase.Attributes;
using HoneyRyderTask.UseCase.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// サービスコレクション
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// DIコンテナにユースケースを追加します。
        /// </summary>
        /// <param name="services"></param>
        public static void AddUseCases(this IServiceCollection services)
        {
            var assembly = UseCaseHelper.GetAssembly();
            var useCaseTypes = assembly.GetTypes()
                .Where(t => t.HasAttribute<UseCaseAttribute>());
            foreach (Type useCaseType in useCaseTypes)
            {
                services.AddTransient(useCaseType);
            }
        }
    }
}
