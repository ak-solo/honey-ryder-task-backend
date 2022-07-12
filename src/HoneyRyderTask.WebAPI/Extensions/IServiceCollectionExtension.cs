using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTask.Infrastructure.PostgreSQL.Repositories.Tasks;
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
        /// DIコンテナにリポジトリを追加します。
        /// </summary>
        /// <param name="services">サービスコレクション</param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
        }

        /// <summary>
        /// DIコンテナにドメインサービスを追加します。
        /// </summary>
        /// <param name="services">サービスコレクション</param>
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();
            services.AddTransient<ITaskFactory, HoneyRyderTask.Domain.Services.Tasks.TaskFactory>();
        }

        /// <summary>
        /// DIコンテナにユースケースを追加します。
        /// </summary>
        /// <param name="services">サービスコレクション</param>
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
