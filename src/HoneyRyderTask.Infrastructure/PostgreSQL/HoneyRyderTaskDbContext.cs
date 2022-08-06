using HoneyRyderTask.Infrastructure.PostgreSQL.DataModels.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HoneyRyderTask.Infrastructure.PostgreSQL
{
    /// <summary>
    /// DBコンテキスト
    /// </summary>
    public class HoneyRyderTaskDbContext : DbContext
    {
        /// <summary>
        /// タスク
        /// </summary>
        public DbSet<TaskDataModel> Tasks => this.Set<TaskDataModel>();

        /// <summary>
        /// DB構成
        /// </summary>
        /// <param name="optionsBuilder">オプションビルダー</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<HoneyRyderTaskDbContext>()
                .Build();
            optionsBuilder.UseNpgsql(configuration["DefaultConnection"]);
        }
    }
}
